using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Diagnostics;
using Microsoft.AspNetCore;
using Agenda.Models;

namespace Agenda.Models
{
    public class AgendaModel
    {
        [Key]
        public int id{get;set;}
        public string nome {get;set;}
        public string sobrenome{get;set;}
    }
}