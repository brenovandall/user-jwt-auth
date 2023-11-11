﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using UserAuth.Data.Dtos;
using UserAuth.Models;
using UserAuth.Services;

namespace UserAuth.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    // tasks represent asynchronous operations, enabling concurrent execution without blocking the main thread
    [HttpPost("sign")] 
    public async Task<IActionResult> UserCreating(UserDto user)
    {
        await _userService.Sign(user); // wait for service request 
        return Ok("User successfully signed"); // can return ok because its on the controller, so if system gets off the service, it can return ok to the client
    }

    [HttpPost("login")] 
    public async Task<IActionResult> LoginUser(UserLoginDto logindto)
    {
        var token = await _userService.Login(logindto); // wait for service request 
        return Ok(token.ToString()); // can return ok because its on the controller, so if system gets off the service, it can return ok and token message
    }
}