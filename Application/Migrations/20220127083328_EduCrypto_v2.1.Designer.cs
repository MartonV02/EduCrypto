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
    [Migration("20220127083328_EduCrypto_v2.1")]
    partial class EduCrypto_v21
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.13");

            modelBuilder.Entity("Application.CryptoCurrencies.CryptoCurrencyModel", b =>
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

            modelBuilder.Entity("Application.Group.GroupModel", b =>
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

            modelBuilder.Entity("Application.Images.ImageModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("IamageTitle")
                        .HasColumnType("longtext");

                    b.Property<byte[]>("ImageData")
                        .HasColumnType("longblob");

                    b.HasKey("Id");

                    b.ToTable("ImageModel");
                });

            modelBuilder.Entity("Application.UserCrypto.UserCryptoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("cryptoCurrencyId")
                        .HasColumnType("int");

                    b.Property<double>("cryptoValue")
                        .HasColumnType("double");

                    b.Property<bool>("isFavourite")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("userForGroupsModelId")
                        .HasColumnType("int");

                    b.Property<int?>("userHandlingModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("cryptoCurrencyId");

                    b.HasIndex("userForGroupsModelId");

                    b.HasIndex("userHandlingModelId");

                    b.ToTable("UserCryptos");
                });

            modelBuilder.Entity("Application.UserForGroups.UserForGroupsModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("accesLevel")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("groupModelId")
                        .HasColumnType("int");

                    b.Property<string>("groupWalletNumber")
                        .IsRequired()
                        .HasMaxLength(34)
                        .HasColumnType("varchar(34)");

                    b.Property<decimal>("money")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int?>("userHandlingModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("groupModelId");

                    b.HasIndex("userHandlingModelId");

                    b.ToTable("UserForGroups");
                });

            modelBuilder.Entity("Application.UserHandling.UserHandlingModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("birthDate")
                        .HasColumnType("datetime");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("fullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("moneyDollar")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int?>("profilePictureId")
                        .HasColumnType("int");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("walletNumber")
                        .HasMaxLength(34)
                        .HasColumnType("varchar(34)");

                    b.Property<int>("xpLevel")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("profilePictureId");

                    b.ToTable("UserHandlings");
                });

            modelBuilder.Entity("Application.UserTradeHistory.UserTradeHistoryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("boughtCryptoCurrencyModelId")
                        .HasColumnType("int");

                    b.Property<decimal>("boughtValue")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int?>("spentCryptoCurrencyModelId")
                        .HasColumnType("int");

                    b.Property<decimal>("spentValue")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime>("tradeDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("userForGroupsModelId")
                        .HasColumnType("int");

                    b.Property<int?>("userHandlingModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("boughtCryptoCurrencyModelId");

                    b.HasIndex("spentCryptoCurrencyModelId");

                    b.HasIndex("userForGroupsModelId");

                    b.HasIndex("userHandlingModelId");

                    b.ToTable("UserTradeHistories");
                });

            modelBuilder.Entity("Application.UserCrypto.UserCryptoModel", b =>
                {
                    b.HasOne("Application.CryptoCurrencies.CryptoCurrencyModel", "cryptoCurrency")
                        .WithMany()
                        .HasForeignKey("cryptoCurrencyId");

                    b.HasOne("Application.UserForGroups.UserForGroupsModel", "userForGroupsModel")
                        .WithMany()
                        .HasForeignKey("userForGroupsModelId");

                    b.HasOne("Application.UserHandling.UserHandlingModel", "userHandlingModel")
                        .WithMany()
                        .HasForeignKey("userHandlingModelId");

                    b.Navigation("cryptoCurrency");

                    b.Navigation("userForGroupsModel");

                    b.Navigation("userHandlingModel");
                });

            modelBuilder.Entity("Application.UserForGroups.UserForGroupsModel", b =>
                {
                    b.HasOne("Application.Group.GroupModel", "groupModel")
                        .WithMany()
                        .HasForeignKey("groupModelId");

                    b.HasOne("Application.UserHandling.UserHandlingModel", "userHandlingModel")
                        .WithMany()
                        .HasForeignKey("userHandlingModelId");

                    b.Navigation("groupModel");

                    b.Navigation("userHandlingModel");
                });

            modelBuilder.Entity("Application.UserHandling.UserHandlingModel", b =>
                {
                    b.HasOne("Application.Images.ImageModel", "profilePicture")
                        .WithMany()
                        .HasForeignKey("profilePictureId");

                    b.Navigation("profilePicture");
                });

            modelBuilder.Entity("Application.UserTradeHistory.UserTradeHistoryModel", b =>
                {
                    b.HasOne("Application.CryptoCurrencies.CryptoCurrencyModel", "boughtCryptoCurrencyModel")
                        .WithMany()
                        .HasForeignKey("boughtCryptoCurrencyModelId");

                    b.HasOne("Application.CryptoCurrencies.CryptoCurrencyModel", "spentCryptoCurrencyModel")
                        .WithMany()
                        .HasForeignKey("spentCryptoCurrencyModelId");

                    b.HasOne("Application.UserForGroups.UserForGroupsModel", "userForGroupsModel")
                        .WithMany()
                        .HasForeignKey("userForGroupsModelId");

                    b.HasOne("Application.UserHandling.UserHandlingModel", "userHandlingModel")
                        .WithMany()
                        .HasForeignKey("userHandlingModelId");

                    b.Navigation("boughtCryptoCurrencyModel");

                    b.Navigation("spentCryptoCurrencyModel");

                    b.Navigation("userForGroupsModel");

                    b.Navigation("userHandlingModel");
                });
#pragma warning restore 612, 618
        }
    }
}
