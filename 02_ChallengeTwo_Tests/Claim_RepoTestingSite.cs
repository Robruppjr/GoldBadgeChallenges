using System.Collections.Generic;
using Xunit;
public class Claim_RepoTestingSite
{
    private readonly ClaimRepository _claimRepo;
    private Claim _claim;
    public Claim_RepoTestingSite()
    {
        _claimRepo = new ClaimRepository();
        _claim = new Claim(1, ClaimType.Car, "Car Accident on 454", 400.00m, new System.DateTime(2018,04,27), new System.DateTime(2018,04,28));
        _claimRepo.AddClaimToTheDatabase(_claim);
    }
        [Fact]
        public void AddClaimToTheDatabase_ShouldReturnTrue()
        {
            var claim = new Claim(1, ClaimType.Home, "Break in, Damaged Property", 750.00m, new System.DateTime(2022,04,27), new System.DateTime(2022,04,30));
            var expectingTrue = _claimRepo.AddClaimToTheDatabase(claim);
            Assert.True(expectingTrue);
        }
        [Fact]
        public void GetAllClaims_CountShouldMatch()
        {
            var claim = new Claim(1, ClaimType.Home, "Break in, Damaged Property", 750.00m, new System.DateTime(2022,04,27), new System.DateTime(2022,04,30));
            _claimRepo.AddClaimToTheDatabase(claim);
            var expectedClaimsCount = 2;
            var actual = _claimRepo.GetClaims().Count;
            Assert.Equal(expectedClaimsCount,actual);
        }
        [Fact]
        public void GetClaim_ShouldReturnClaim()
        {
            
        }
        [Fact]
        public void FinishClaim_ShouldReturn_True()
        {
            
        }
}