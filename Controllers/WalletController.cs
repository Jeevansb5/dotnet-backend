using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OracleJwtApiFull.DTOs;
using OracleJwtApiFull.Services.Interfaces;
using System;

namespace OracleJwtApiFull.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class WalletController : ControllerBase
    {
        private readonly IWalletService _walletService;

        public WalletController(IWalletService walletService)
        {
            _walletService = walletService;
        }

        // Replace with real user ID retrieval from token
        private int GetUserId()
        {
            var userIdClaim = User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
            return int.Parse(userIdClaim.Value);
        }

        [HttpGet("balance")]
        public IActionResult GetBalance()
        {
            try
            {
                var balance = _walletService.GetBalance(GetUserId());
                return Ok(balance);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("credit")]
        public IActionResult Credit([FromBody] WalletTransactionDTO request)
        {
            return Ok(_walletService.Credit(GetUserId(), request.Amount));
        }

        [HttpPost("debit")]
        public IActionResult Debit([FromBody] WalletTransactionDTO request)
        {
            try
            {
                return Ok(_walletService.Debit(GetUserId(), request.Amount));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpGet("transactions")]
        //public IActionResult GetTransactions()
        //{
        //    return Ok(_walletService.GetTransactions(GetUserId()));
        //}
    }
}
