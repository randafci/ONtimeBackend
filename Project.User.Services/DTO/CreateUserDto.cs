﻿namespace OnTime.User.Services.DTO
{
    public class CreateUserDto
    {
      //  public string UserName { get; set; }
      //  public string Email { get; set; }
        public string Password { get; set; }
        public bool IsLdapUser { get; set; }
        public string ExtraEmployeesView { get; set; }
        public long? EmployeeId { get; set; }
    }

}
