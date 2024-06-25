﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wizzarts.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Avatars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Avatar Name. Seeded."),
                    AvatarUrl = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Avatar Remote URL. Seeded."),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avatars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlackMana",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cost = table.Column<int>(type: "int", nullable: false, comment: "Play Card Total Cost"),
                    ColorName = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Play Card Mana Color Name"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Play Card Remote URL. Seeded."),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlackMana", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlueMana",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cost = table.Column<int>(type: "int", nullable: false, comment: "Play Card Total Cost"),
                    ColorName = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Play Card Mana Color Name"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Play Card Remote URL. Seeded."),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlueMana", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CardGameExpansions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Card game expansion title.Seeded"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Card game expansion description. Seeded"),
                    ExpansionSymbolUrl = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Card game expansion symbol. Seeded"),
                    CardsCount = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Numbwer of cards by expansion. Seeded"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardGameExpansions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ColorlessMana",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cost = table.Column<int>(type: "int", nullable: false, comment: "Play Card Total Cost"),
                    ColorName = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Play Card Mana Conor Name"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Play Card Remote URL. Seeded."),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorlessMana", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Event status.Seeded"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GreenMana",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cost = table.Column<int>(type: "int", nullable: false, comment: "Play Card Total Cost"),
                    ColorName = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Play Card Mana Color Name"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Play Card Remote URL. Seeded."),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GreenMana", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayCardFrameColors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Play Card Frame color. Seeded"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Play Remote Image. Seeded"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayCardFrameColors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayCardTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Card type is."),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayCardTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RedMana",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cost = table.Column<int>(type: "int", nullable: false, comment: "Play Card Total Cost"),
                    ColorName = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Play Card Mana Color Name"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Play Card Remote URL. Seeded."),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RedMana", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WhiteMana",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cost = table.Column<int>(type: "int", nullable: false, comment: "Play Card Total Cost"),
                    ColorName = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Play Card Mana Color Name"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Play Card Remote URL. Seeded."),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WhiteMana", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WizzartsCardGame",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardGameRulesId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WizzartsCardGame", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Article title"),
                    ShortDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Article short description"),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, comment: "Article description"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Article image URL"),
                    ApprovedByAdmin = table.Column<bool>(type: "bit", nullable: false, comment: "Is Article approved by Admin."),
                    ArticleCreatorId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Article creator identifier"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_AspNetUsers_ArticleCreatorId",
                        column: x => x.ArticleCreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Arts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Art Title"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true, comment: "Art Description"),
                    RemoteImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Art url"),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Image extension"),
                    ApprovedByAdmin = table.Column<bool>(type: "bit", nullable: false, comment: "New art piece  has been approved or not"),
                    AddedByMemberId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Arts_AspNetUsers_AddedByMemberId",
                        column: x => x.AddedByMemberId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Arts_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Store name"),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Store location"),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Store location"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Store phone"),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Store location"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Store image Url"),
                    ApprovedByAdmin = table.Column<bool>(type: "bit", nullable: false, comment: "Store approved by Admin."),
                    StoreOwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stores_AspNetUsers_StoreOwnerId",
                        column: x => x.StoreOwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WizzartsMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nickname = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    AvatarUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Avatar remote URL.Picked after signing in"),
                    AvatarId = table.Column<int>(type: "int", nullable: false, comment: "Avatar Identifier.Picked after signing in"),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Information about the artist"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Artist's eamil"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true, comment: "Artist's user id"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WizzartsMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WizzartsMembers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WizzartsMembers_Avatars_AvatarId",
                        column: x => x.AvatarId,
                        principalTable: "Avatars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Event Title"),
                    EventDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, comment: "Event Description"),
                    RemoteImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Event image url"),
                    EventStatusId = table.Column<int>(type: "int", nullable: false, comment: "Event status"),
                    ApprovedByAdmin = table.Column<bool>(type: "bit", nullable: false, comment: "Is event approved by admin."),
                    EventCreatorId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Event creator"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_AspNetUsers_EventCreatorId",
                        column: x => x.EventCreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Events_EventStatuses_EventStatusId",
                        column: x => x.EventStatusId,
                        principalTable: "EventStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WizzartsGameRules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameRulesIntroUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardReading = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardReadingIntroUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardNameReading = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardNameUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManaCostReading = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManaCostUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardTypeReading = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardTypeUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SetSymbolReading = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SetSymbolUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardTextBoxReading = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardTextBoxUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardPowerToughnessReading = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardPowToughUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BattleFieldSetUp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BattleFieldIntroUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreaturesInBattle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LibraryInBattle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LandsInBattle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GraveyardInBattle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HandInBattle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameActions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TappingUntapping = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CastingSpells = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttackingAndBlocking = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartsOfTheTurn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeginningPhase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstMainPhase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CombatPhase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondMainPhase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndingPhase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Outro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OutroUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublishedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WizzartsCardGameId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WizzartsGameRules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WizzartsGameRules_WizzartsCardGame_WizzartsCardGameId",
                        column: x => x.WizzartsCardGameId,
                        principalTable: "WizzartsCardGame",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WizzartsGameRulesData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Game rule component title. Seeded"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Game rule component description. Seeded"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Game rule component image url. Seeded"),
                    WizzartsCardGameId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WizzartsGameRulesData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WizzartsGameRulesData_WizzartsCardGame_WizzartsCardGameId",
                        column: x => x.WizzartsCardGameId,
                        principalTable: "WizzartsCardGame",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WizzartsTeamMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nickname = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Information about the artist"),
                    AvatarUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Avatar remote URL.Picked after signing in"),
                    WizzartsCardGameId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true, comment: "Wizzarts Team user id"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WizzartsTeamMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WizzartsTeamMembers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WizzartsTeamMembers_WizzartsCardGame_WizzartsCardGameId",
                        column: x => x.WizzartsCardGameId,
                        principalTable: "WizzartsCardGame",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EventComponents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Title"),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, comment: "Description"),
                    Instructions = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Instructions"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Image"),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    RequireArtInput = table.Column<bool>(type: "bit", nullable: false, comment: "Does it require art input"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventComponents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventComponents_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlayCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Playcard name"),
                    BlackManaId = table.Column<int>(type: "int", nullable: true, comment: "Mana cost Id"),
                    BlueManaId = table.Column<int>(type: "int", nullable: true, comment: "Mana cost Id"),
                    RedManaId = table.Column<int>(type: "int", nullable: true, comment: "Mana cost Id"),
                    WhiteManaId = table.Column<int>(type: "int", nullable: true, comment: "Mana cost Id"),
                    GreenManaId = table.Column<int>(type: "int", nullable: true, comment: "Mana cost Id"),
                    ColorlessManaId = table.Column<int>(type: "int", nullable: true, comment: "Mana cost Id"),
                    CardFrameColorId = table.Column<int>(type: "int", nullable: true, comment: "Framecolor Id. There is a default value."),
                    CardRemoteUrl = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Image of the card saved locally upon creation."),
                    CardTypeId = table.Column<int>(type: "int", nullable: true, comment: "Card type identifier."),
                    AbilitiesAndFlavor = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "Card use requirements and effects. Card power description."),
                    Power = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true, comment: "Card will deal damage equal to power."),
                    Toughness = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true, comment: "Card can take damage up to amount equal to its toughness."),
                    CardGameExpansionId = table.Column<int>(type: "int", nullable: false, comment: "This card is part of which expansion."),
                    IsEventCard = table.Column<bool>(type: "bit", nullable: false, comment: "Has this card been created during an event."),
                    IsBanned = table.Column<bool>(type: "bit", nullable: false, comment: "Has this card been created during an event."),
                    ArtId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AddedByMemberId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApprovedByAdmin = table.Column<bool>(type: "bit", nullable: false, comment: "Has this card been approved by admin."),
                    EventId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayCards_Arts_ArtId",
                        column: x => x.ArtId,
                        principalTable: "Arts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayCards_AspNetUsers_AddedByMemberId",
                        column: x => x.AddedByMemberId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayCards_BlackMana_BlackManaId",
                        column: x => x.BlackManaId,
                        principalTable: "BlackMana",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayCards_BlueMana_BlueManaId",
                        column: x => x.BlueManaId,
                        principalTable: "BlueMana",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayCards_CardGameExpansions_CardGameExpansionId",
                        column: x => x.CardGameExpansionId,
                        principalTable: "CardGameExpansions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayCards_ColorlessMana_ColorlessManaId",
                        column: x => x.ColorlessManaId,
                        principalTable: "ColorlessMana",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayCards_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayCards_GreenMana_GreenManaId",
                        column: x => x.GreenManaId,
                        principalTable: "GreenMana",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayCards_PlayCardFrameColors_CardFrameColorId",
                        column: x => x.CardFrameColorId,
                        principalTable: "PlayCardFrameColors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayCards_PlayCardTypes_CardTypeId",
                        column: x => x.CardTypeId,
                        principalTable: "PlayCardTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayCards_RedMana_RedManaId",
                        column: x => x.RedManaId,
                        principalTable: "RedMana",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayCards_WhiteMana_WhiteManaId",
                        column: x => x.WhiteManaId,
                        principalTable: "WhiteMana",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CardComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Card title"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Card Description"),
                    Review = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "CardReview"),
                    Suggestions = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "What can be done to resolve the issue."),
                    CardId = table.Column<int>(type: "int", nullable: false, comment: "Review of which card"),
                    PostedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardComments_AspNetUsers_PostedByUserId",
                        column: x => x.PostedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CardComments_PlayCards_CardId",
                        column: x => x.CardId,
                        principalTable: "PlayCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ManaInCard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Mana color type."),
                    RemoteImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Mana remote image url."),
                    CardId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManaInCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManaInCard_PlayCards_CardId",
                        column: x => x.CardId,
                        principalTable: "PlayCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Votes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardId = table.Column<int>(type: "int", nullable: false, comment: "Vote added to."),
                    AddedByMemberId = table.Column<string>(type: "nvarchar(450)", nullable: true, comment: "Vote casted by."),
                    Value = table.Column<byte>(type: "tinyint", nullable: false, comment: "Vote value"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Votes_AspNetUsers_AddedByMemberId",
                        column: x => x.AddedByMemberId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Votes_PlayCards_CardId",
                        column: x => x.CardId,
                        principalTable: "PlayCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ArticleCreatorId",
                table: "Articles",
                column: "ArticleCreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_IsDeleted",
                table: "Articles",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Arts_AddedByMemberId",
                table: "Arts",
                column: "AddedByMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Arts_ApplicationUserId",
                table: "Arts",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Arts_IsDeleted",
                table: "Arts",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_IsDeleted",
                table: "AspNetRoles",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IsDeleted",
                table: "AspNetUsers",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Avatars_IsDeleted",
                table: "Avatars",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_BlackMana_IsDeleted",
                table: "BlackMana",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_BlueMana_IsDeleted",
                table: "BlueMana",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CardComments_CardId",
                table: "CardComments",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_CardComments_IsDeleted",
                table: "CardComments",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CardComments_PostedByUserId",
                table: "CardComments",
                column: "PostedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CardGameExpansions_IsDeleted",
                table: "CardGameExpansions",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ColorlessMana_IsDeleted",
                table: "ColorlessMana",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_EventComponents_EventId",
                table: "EventComponents",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventComponents_IsDeleted",
                table: "EventComponents",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventCreatorId",
                table: "Events",
                column: "EventCreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventStatusId",
                table: "Events",
                column: "EventStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_IsDeleted",
                table: "Events",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_EventStatuses_IsDeleted",
                table: "EventStatuses",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_GreenMana_IsDeleted",
                table: "GreenMana",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ManaInCard_CardId",
                table: "ManaInCard",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_ManaInCard_IsDeleted",
                table: "ManaInCard",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_PlayCardFrameColors_IsDeleted",
                table: "PlayCardFrameColors",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_PlayCards_AddedByMemberId",
                table: "PlayCards",
                column: "AddedByMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayCards_ArtId",
                table: "PlayCards",
                column: "ArtId",
                unique: true,
                filter: "[ArtId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PlayCards_BlackManaId",
                table: "PlayCards",
                column: "BlackManaId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayCards_BlueManaId",
                table: "PlayCards",
                column: "BlueManaId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayCards_CardFrameColorId",
                table: "PlayCards",
                column: "CardFrameColorId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayCards_CardGameExpansionId",
                table: "PlayCards",
                column: "CardGameExpansionId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayCards_CardTypeId",
                table: "PlayCards",
                column: "CardTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayCards_ColorlessManaId",
                table: "PlayCards",
                column: "ColorlessManaId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayCards_EventId",
                table: "PlayCards",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayCards_GreenManaId",
                table: "PlayCards",
                column: "GreenManaId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayCards_IsDeleted",
                table: "PlayCards",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_PlayCards_RedManaId",
                table: "PlayCards",
                column: "RedManaId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayCards_WhiteManaId",
                table: "PlayCards",
                column: "WhiteManaId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayCardTypes_IsDeleted",
                table: "PlayCardTypes",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_RedMana_IsDeleted",
                table: "RedMana",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Settings_IsDeleted",
                table: "Settings",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_IsDeleted",
                table: "Stores",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_StoreOwnerId",
                table: "Stores",
                column: "StoreOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_AddedByMemberId",
                table: "Votes",
                column: "AddedByMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_CardId",
                table: "Votes",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_IsDeleted",
                table: "Votes",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_WhiteMana_IsDeleted",
                table: "WhiteMana",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_WizzartsCardGame_IsDeleted",
                table: "WizzartsCardGame",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_WizzartsGameRules_IsDeleted",
                table: "WizzartsGameRules",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_WizzartsGameRules_WizzartsCardGameId",
                table: "WizzartsGameRules",
                column: "WizzartsCardGameId",
                unique: true,
                filter: "[WizzartsCardGameId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_WizzartsGameRulesData_IsDeleted",
                table: "WizzartsGameRulesData",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_WizzartsGameRulesData_WizzartsCardGameId",
                table: "WizzartsGameRulesData",
                column: "WizzartsCardGameId");

            migrationBuilder.CreateIndex(
                name: "IX_WizzartsMembers_AvatarId",
                table: "WizzartsMembers",
                column: "AvatarId");

            migrationBuilder.CreateIndex(
                name: "IX_WizzartsMembers_IsDeleted",
                table: "WizzartsMembers",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_WizzartsMembers_UserId",
                table: "WizzartsMembers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WizzartsTeamMembers_IsDeleted",
                table: "WizzartsTeamMembers",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_WizzartsTeamMembers_UserId",
                table: "WizzartsTeamMembers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WizzartsTeamMembers_WizzartsCardGameId",
                table: "WizzartsTeamMembers",
                column: "WizzartsCardGameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CardComments");

            migrationBuilder.DropTable(
                name: "EventComponents");

            migrationBuilder.DropTable(
                name: "ManaInCard");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "Votes");

            migrationBuilder.DropTable(
                name: "WizzartsGameRules");

            migrationBuilder.DropTable(
                name: "WizzartsGameRulesData");

            migrationBuilder.DropTable(
                name: "WizzartsMembers");

            migrationBuilder.DropTable(
                name: "WizzartsTeamMembers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "PlayCards");

            migrationBuilder.DropTable(
                name: "Avatars");

            migrationBuilder.DropTable(
                name: "WizzartsCardGame");

            migrationBuilder.DropTable(
                name: "Arts");

            migrationBuilder.DropTable(
                name: "BlackMana");

            migrationBuilder.DropTable(
                name: "BlueMana");

            migrationBuilder.DropTable(
                name: "CardGameExpansions");

            migrationBuilder.DropTable(
                name: "ColorlessMana");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "GreenMana");

            migrationBuilder.DropTable(
                name: "PlayCardFrameColors");

            migrationBuilder.DropTable(
                name: "PlayCardTypes");

            migrationBuilder.DropTable(
                name: "RedMana");

            migrationBuilder.DropTable(
                name: "WhiteMana");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "EventStatuses");
        }
    }
}
