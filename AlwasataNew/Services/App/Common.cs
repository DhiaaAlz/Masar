using AlwasataNew.Data;

namespace AlwasataNew.Services.App
{
    public class Common:ICommon
    {
        private readonly ApplicationDbContext _context= new ApplicationDbContext();

        public Common()
        {
            
        }
       
        public List<string> GetCliecntSource()
        {
            return new List<string>()
            {
                "داتا",
                "موظفين",
                "مسوقين",
                "اخر",
            };
        }

        public List<string> GetCliecntSourceEmployee()
        {
            List<string> EmployeesIdList = new List<string>();
            var idForEmployeePrivailage = _context.Roles.Where(x=>x.Name == "Marketer").Select(x=>x.Id).FirstOrDefault();
            var employees = _context.UserRoles.Where(x=>x.RoleId!=idForEmployeePrivailage).Select(x=>x.UserId).ToList();
            EmployeesIdList.AddRange(employees);
            
            return EmployeesIdList;
        }

        public List<string> GetCliecntSourceMarketer()
        {
            List<string> EmployeesIdList = new List<string>();
            var idForEmployeePrivailage = _context.Roles.Where(x => x.Name == "Marketer").Select(x => x.Id).FirstOrDefault();
            var employees = _context.UserRoles.Where(x => x.RoleId == idForEmployeePrivailage).Select(x => x.UserId).ToList();
            EmployeesIdList.AddRange(employees);

            return EmployeesIdList;
        }

    }
}
