﻿// <auto-generated />
using System;
using Application.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Application.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220113145404_testKeys_v4")]
    partial class testKeys_v4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.13");

            modelBuilder.Entity("Application.CryptoCurrencies.CryptoCurrency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("circulatingSupply")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("contraction")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("varchar(5)");

                    b.Property<decimal>("dayPercent")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("marketCap")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<decimal>("price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("volume")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("weekPercent")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.ToTable("CryptoCurrencies");
                });

            modelBuilder.Entity("Application.Group.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("finishDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("isFinished")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("startBudget")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Application.Images.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("IamageTitle")
                        .HasColumnType("longtext");

                    b.Property<byte[]>("ImageData")
                        .HasColumnType("longblob");

                    b.HasKey("Id");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("Application.UserCrypto.UserCrypto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("cryptoCurrencyId")
                        .HasColumnType("int");

                    b.Property<double>("cryptoValue")
                        .HasColumnType("double");

                    b.Property<string>("groupWalletNumber")
                        .HasMaxLength(34)
                        .HasColumnType("varchar(34)");

                    b.Property<bool>("isFavourite")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("userFinanceId")
                        .HasColumnType("int");

                    b.Property<int?>("userForGroupsId")
                        .HasColumnType("int");

                    b.Property<string>("walletNumber")
                        .HasMaxLength(34)
                        .HasColumnType("varchar(34)");

                    b.HasKey("Id");

                    b.HasIndex("cryptoCurrencyId");

                    b.HasIndex("userFinanceId");

                    b.HasIndex("userForGroupsId");

                    b.ToTable("UserCryptos");
                });

            modelBuilder.Entity("Application.UserFinance.UserFinance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("moneyDollar")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int?>("userHandlingId")
                        .HasColumnType("int");

                    b.Property<int?>("userId")
                        .HasColumnType("int");

                    b.Property<string>("walletNumber")
                        .IsRequired()
                        .HasMaxLength(34)
                        .HasColumnType("varchar(34)");

                    b.HasKey("Id");

                    b.HasIndex("userHandlingId");

                    b.ToTable("UserFinances");
                });

            modelBuilder.Entity("Application.UserForGroups.UserForGroups", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("accesLevel")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("groupId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("groupWalletNumber")
                        .IsRequired()
                        .HasMaxLength(34)
                        .HasColumnType("varchar(34)");

                    b.Property<decimal>("money")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int?>("userHandlingId")
                        .HasColumnType("int");

                    b.Property<int?>("userId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("groupId");

                    b.HasIndex("userHandlingId");

                    b.ToTable("UserForGroups");
                });

            modelBuilder.Entity("Application.UserHandling.UserHandling", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("birthDate")
                        .HasColumnType("datetime");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("fullNme")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("profilePictureIdId")
                        .HasColumnType("int");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("xpLevel")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("profilePictureIdId");

                    b.ToTable("UserHandlings");
                });

            modelBuilder.Entity("Application.UserTradeHistory.UserTradeHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("boughtCryptoCurrencyId")
                        .HasColumnType("int");

                    b.Property<int?>("boughtId")
                        .HasColumnType("int");

                    b.Property<decimal>("boughtValue")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int?>("groupId")
                        .HasColumnType("int");

                    b.Property<int?>("spentCryptoCurrencyId")
                        .HasColumnType("int");

                    b.Property<int?>("spentId")
                        .HasColumnType("int");

                    b.Property<decimal>("spentValue")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime>("tradeDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("userHandlingId")
                        .HasColumnType("int");

                    b.Property<int?>("userId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("boughtCryptoCurrencyId");

                    b.HasIndex("groupId");

                    b.HasIndex("spentCryptoCurrencyId");

                    b.HasIndex("userHandlingId");

                    b.ToTable("UserTradeHistories");
                });

            modelBuilder.Entity("Application.UserCrypto.UserCrypto", b =>
                {
                    b.HasOne("Application.CryptoCurrencies.CryptoCurrency", "cryptoCurrency")
                        .WithMany()
                        .HasForeignKey("cryptoCurrencyId");

                    b.HasOne("Application.UserFinance.UserFinance", "userFinance")
                        .WithMany()
                        .HasForeignKey("userFinanceId");

                    b.HasOne("Application.UserForGroups.UserForGroups", "userForGroups")
                        .WithMany()
                        .HasForeignKey("userForGroupsId");

                    b.Navigation("cryptoCurrency");

                    b.Navigation("userFinance");

                    b.Navigation("userForGroups");
                });

            modelBuilder.Entity("Application.UserFinance.UserFinance", b =>
                {
                    b.HasOne("Application.UserHandling.UserHandling", "userHandling")
                        .WithMany()
                        .HasForeignKey("userHandlingId");

                    b.Navigation("userHandling");
                });

            modelBuilder.Entity("Application.UserForGroups.UserForGroups", b =>
                {
                    b.HasOne("Application.Group.Group", "group")
                        .WithMany()
                        .HasForeignKey("groupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Application.UserHandling.UserHandling", "userHandling")
                        .WithMany()
                        .HasForeignKey("userHandlingId");

                    b.Navigation("group");

                    b.Navigation("userHandling");
                });

            modelBuilder.Entity("Application.UserHandling.UserHandling", b =>
                {
                    b.HasOne("Application.Images.Image", "profilePictureId")
                        .WithMany()
                        .HasForeignKey("profilePictureIdId");

                    b.Navigation("profilePictureId");
                });

            modelBuilder.Entity("Application.UserTradeHistory.UserTradeHistory", b =>
                {
                    b.HasOne("Application.CryptoCurrencies.CryptoCurrency", "boughtCryptoCurrency")
                        .WithMany()
                        .HasForeignKey("boughtCryptoCurrencyId");

                    b.HasOne("Application.Group.Group", "group")
                        .WithMany()
                        .HasForeignKey("groupId");

                    b.HasOne("Application.CryptoCurrencies.CryptoCurrency", "spentCryptoCurrency")
                        .WithMany()
                        .HasForeignKey("spentCryptoCurrencyId");

                    b.HasOne("Application.UserHandling.UserHandling", "userHandling")
                        .WithMany()
                        .HasForeignKey("userHandlingId");

                    b.Navigation("boughtCryptoCurrency");

                    b.Navigation("group");

                    b.Navigation("spentCryptoCurrency");

                    b.Navigation("userHandling");
                });
#pragma warning restore 612, 618
        }
    }
}
