using System.Net.Http.Json;

namespace BlazorWasmApp.Services
{
    public class Student
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public DateTime? CreatedOn { get; set; }
    }

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
    }
}
