using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
    public class ClaimRepository
    {
        private readonly Queue<Claim> _claimDatabase = new Queue<Claim>();
        private int _count = 0;
        public bool AddClaimToTheDatabase(Claim claim)
        {
            if (claim != null)
            {
                _count++;
                claim.ID = _count;
                _claimDatabase.Enqueue(claim);
                return true;
            }
            return false;
        }
        public Queue<Claim> GetClaims()
        {
            return _claimDatabase;
        }
        public Claim GetClaim()
        {
            if(_claimDatabase.Count > 0)
            {
                var claim = _claimDatabase.Peek();
                return claim;
            }
            else 
            {
                return null;
            }
        }
        public bool FinishClaim()
        {
            var claim = GetClaim();
            if(claim != null)
            {
                _claimDatabase.Dequeue();
                return true;
            }
            else
            {
                return false;
            }
        }
    }