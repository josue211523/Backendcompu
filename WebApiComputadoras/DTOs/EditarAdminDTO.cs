﻿using System.ComponentModel.DataAnnotations;

namespace WebApiComputadoras.DTOs
{
    public class EditarAdminDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
