using BlazorWasmApp.Models;

using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;
using System.Text.Json;

namespace BlazorWasmApp.Services
{
    public class StudentsApiClient
    {
        private readonly HttpClient httpClient;

        public StudentsApiClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<Student>?> GetStudentsAsync()
        {
            try
            {
                var response = await httpClient.GetAsync("/students");

                if (response.IsSuccessStatusCode)
                {
                    var students = await response.Content.ReadFromJsonAsync<List<Student>>();
                    return students;
                }
            }
            catch (Exception ex)
            {
                // Log and notify user
            }

            return new List<Student>();
        }

        public async Task AddStudent(Student s)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync<Student>("/students", s);
            }
            catch (Exception ex)
            {
                // Log error
            }
        }
    }
}
