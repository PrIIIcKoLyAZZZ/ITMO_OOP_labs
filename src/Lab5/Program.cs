// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Application.Configs;
using Application.Services;
using Infrastructure.Migrations;
using Infrastructure.Repositories;
using Presentation;
using Presentation.Scenarios.Login;

var config = new Config();

MigrationWorker.SqlUP(config.ConnectionString);

var transactionRepo = new TransactionRepository(config.ConnectionString);
var accountRepo = new AccountRepository(config.ConnectionString);

var accountService = new AccountService(accountRepo, transactionRepo);
var userService = new UserService(config);

var scenarioRunner = new ScenarioRunner(new ChoseLoginVariant(accountService, userService));

scenarioRunner.Run();