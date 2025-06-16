using SWP_SchoolMedicalManagementSystem_BussinessOject.Entity;
using SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.StudentDto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using System.IO;
using SchoolMedicalManagementSystem.Enum;

namespace SWP_SchoolMedicalManagementSystem_Service.Service
{
    public class StudentExcelReader
    {
        static StudentExcelReader()
        {
            // Set EPPlus license
            ExcelPackage.License.SetNonCommercialOrganization("My Organization");
        }

        public async Task<List<StudentRequest>> ReadStudentsFromExcelAsync(Stream fileStream)
        {
            var students = new List<StudentRequest>();

            using (var package = new ExcelPackage(fileStream))
            {
                var worksheet = package.Workbook.Worksheets[0]; // Get first worksheet
                var rowCount = worksheet.Dimension.Rows;

                // Start from row 2 to skip header
                for (int row = 2; row <= rowCount; row++)
                {
                    try
                    {
                        var student = new StudentRequest
                        {
                            StudentCode = worksheet.Cells[row, 1].Value?.ToString(),
                            FullName = worksheet.Cells[row, 2].Value?.ToString(),
                            DateOfBirth = DateTime.Parse(worksheet.Cells[row, 3].Value?.ToString() ?? DateTime.Now.ToString()),
                            Gender = ParseGender(worksheet.Cells[row, 4].Value?.ToString()),
                            Class = worksheet.Cells[row, 5].Value?.ToString(),
                            SchoolYear = worksheet.Cells[row, 6].Value?.ToString()
                        };

                        if (IsValidStudent(student))
                        {
                            students.Add(student);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log error for this row but continue processing
                        Console.WriteLine($"Error processing row {row}: {ex.Message}");
                    }
                }
            }

            return students;
        }

        private bool IsValidStudent(StudentRequest student)
        {
            return !string.IsNullOrWhiteSpace(student.StudentCode) &&
                   !string.IsNullOrWhiteSpace(student.FullName) &&
                   !string.IsNullOrWhiteSpace(student.Class) &&
                   !string.IsNullOrWhiteSpace(student.SchoolYear);
        }

        private Gender ParseGender(string? genderStr)
        {
            if (string.IsNullOrWhiteSpace(genderStr))
                return Gender.Other;

            return genderStr.ToLower() switch
            {
                "male" or "m" => Gender.Male,
                "female" or "f" => Gender.Female,
                _ => Gender.Other
            };
        }
    }
}