﻿namespace AlwasataNew.Models
{
    public class CustomerCommentstbl
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string EmployeeId { get; set; }
        public int StateId { get; set; }
        public int TypeOfCommunicationId { get; set; }
        public string date { get; set; }
    }
}
