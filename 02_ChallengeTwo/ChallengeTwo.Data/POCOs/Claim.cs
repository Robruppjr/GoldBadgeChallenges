using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
    public class Claim
    {
        public Claim(){}
        public Claim(ClaimType claimType, string description, decimal claimAmount, DateTime dateOfAccident, DateTime dateOfClaim)
        {
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfAccident = dateOfAccident;
            DateOfClaim = dateOfClaim;
        }
        public int ID { get; set;}
        public ClaimType ClaimType {get; set;}
        public string Description {get; set;}
        public decimal ClaimAmount {get; set;}
        public DateTime DateOfAccident {get; set;}
        public DateTime DateOfClaim {get; set;}
        public bool IsValid
        {
            get
            {
                if((DateOfClaim - DateOfAccident).Days <= 30)
                    {
                        return true;
                    }
                else
                {
                    return false;
                }
            }
        }
    }
