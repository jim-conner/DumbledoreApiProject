using System;
using System.Collections.Generic;

namespace SpyDuhApiProject2.Models
{
    public class CreateSpyDuhMemberCommand
    {
        public Guid SpyId { get; set; }
        public List<Skill> Skills { get; set;}
        public List<Service> Services { get; set;}
        public List<Guid> Friends { get; set;}
        public List<Guid> Enemies  { get; set;}

    }   
}