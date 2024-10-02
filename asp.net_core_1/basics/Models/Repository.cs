namespace basics.Models

{
    public class Repository
    {
        private static readonly List<Course> _courses = new();

        static Repository()
        {
            _courses = new List<Course>()
            {
                new Course() {
                    Id = 1,
                    Title = "aspnet course", 
                    Description = "güzel bir kurs", 
                    Image="1.resim.jpg",
                    Tags = new string[] {"aspnet", "web geliştirme"},
                    isActive = true,
                    isHome = true
                },

                new Course() {
                    Id = 2, 
                    Title = "php course",    
                    Description = "güzel bir kurs", 
                    Image="2.resim.jpg",
                    Tags = new string[] {"php", "web geliştirme"},
                    isActive = false,
                    isHome = true
                },

                new Course() {
                    Id = 3, 
                    Title = "django course", 
                    Description = "güzel bir kurs", 
                    Image="3.resim.jpg",
                    isActive = true,
                    isHome = false
                }
            };
        }

        public static List<Course> Courses
        {
            get
            {
                return _courses;
            }
        }

        public static Course? GetById(int? id)
        {
            return _courses.FirstOrDefault(c =>  c.Id == id);
        }
    }
}