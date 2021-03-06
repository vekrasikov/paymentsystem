USE [master]
GO
/****** Object:  Database [paymentsystem]    Script Date: 24.02.2020 16:57:11 ******/
CREATE DATABASE [paymentsystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'paymentsystem', FILENAME = N'D:\SQL_BASE\paymentsystem.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'paymentsystem_log', FILENAME = N'D:\SQL_BASE\paymentsystem_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [paymentsystem] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [paymentsystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [paymentsystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [paymentsystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [paymentsystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [paymentsystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [paymentsystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [paymentsystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [paymentsystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [paymentsystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [paymentsystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [paymentsystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [paymentsystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [paymentsystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [paymentsystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [paymentsystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [paymentsystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [paymentsystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [paymentsystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [paymentsystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [paymentsystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [paymentsystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [paymentsystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [paymentsystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [paymentsystem] SET RECOVERY FULL 
GO
ALTER DATABASE [paymentsystem] SET  MULTI_USER 
GO
ALTER DATABASE [paymentsystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [paymentsystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [paymentsystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [paymentsystem] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [paymentsystem] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'paymentsystem', N'ON'
GO
USE [paymentsystem]
GO
/****** Object:  Table [dbo].[Acc]    Script Date: 24.02.2020 16:57:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Acc](
	[id_acc] [int] IDENTITY(1,1) NOT NULL,
	[balance_acc] [float] NOT NULL,
	[client_id] [int] NOT NULL,
	[credit_rate_id] [int] NULL,
	[date_open_acc] [date] NOT NULL,
	[date_close_acc] [date] NOT NULL,
	[status_acc_id] [int] NOT NULL,
	[type_acc_id] [int] NOT NULL,
 CONSTRAINT [PK_Acc] PRIMARY KEY CLUSTERED 
(
	[id_acc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[autopayment]    Script Date: 24.02.2020 16:57:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[autopayment](
	[id_autopayment] [int] IDENTITY(1,1) NOT NULL,
	[sender_id] [int] NOT NULL,
	[recipient_id] [int] NOT NULL,
	[sum] [float] NOT NULL,
	[comm] [varchar](max) NULL,
	[date_payment] [date] NOT NULL,
	[autopayment_range_id] [int] NOT NULL,
	[freezing] [bit] NOT NULL,
 CONSTRAINT [PK_autopayment] PRIMARY KEY CLUSTERED 
(
	[id_autopayment] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[autopayment_range]    Script Date: 24.02.2020 16:57:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[autopayment_range](
	[id_autopayment_range] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NOT NULL,
	[periodicity] [int] NOT NULL,
 CONSTRAINT [PK_autopayment_range] PRIMARY KEY CLUSTERED 
(
	[id_autopayment_range] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[client]    Script Date: 24.02.2020 16:57:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[client](
	[id_client] [int] IDENTITY(1,1) NOT NULL,
	[fio] [varchar](100) NULL,
	[email] [varchar](100) NOT NULL,
	[password] [varchar](100) NOT NULL,
	[phone] [varchar](20) NOT NULL,
	[passport_s] [varchar](100) NOT NULL,
	[passport_n] [varchar](100) NOT NULL,
	[verification] [bit] NOT NULL,
 CONSTRAINT [PK_client] PRIMARY KEY CLUSTERED 
(
	[id_client] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[credit_rate]    Script Date: 24.02.2020 16:57:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[credit_rate](
	[id_credit_rate] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NOT NULL,
	[condition] [varchar](max) NOT NULL,
	[procent] [float] NOT NULL,
	[credit_limit] [float] NOT NULL,
 CONSTRAINT [PK_credit_rate] PRIMARY KEY CLUSTERED 
(
	[id_credit_rate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[payment]    Script Date: 24.02.2020 16:57:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[payment](
	[id_payment] [int] IDENTITY(1,1) NOT NULL,
	[sender_id] [int] NOT NULL,
	[recipient_id] [int] NOT NULL,
	[sum] [float] NOT NULL,
	[comm] [varchar](max) NULL,
 CONSTRAINT [PK_payment] PRIMARY KEY CLUSTERED 
(
	[id_payment] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[payment_history]    Script Date: 24.02.2020 16:57:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[payment_history](
	[id_payment_history] [int] IDENTITY(1,1) NOT NULL,
	[payment_id] [int] NOT NULL,
	[status_payment_id] [int] NOT NULL,
	[date_check] [date] NOT NULL,
	[rejection] [varchar](max) NULL,
 CONSTRAINT [PK_payment_history] PRIMARY KEY CLUSTERED 
(
	[id_payment_history] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[request]    Script Date: 24.02.2020 16:57:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[request](
	[id_request] [int] IDENTITY(1,1) NOT NULL,
	[income] [float] NOT NULL,
	[place_job] [varchar](max) NOT NULL,
	[client_id] [int] NOT NULL,
	[status_request_id] [int] NOT NULL,
	[type_acc_id] [int] NOT NULL,
 CONSTRAINT [PK_request] PRIMARY KEY CLUSTERED 
(
	[id_request] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[status_acc]    Script Date: 24.02.2020 16:57:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[status_acc](
	[id_status_acc] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NOT NULL,
 CONSTRAINT [PK_status_acc] PRIMARY KEY CLUSTERED 
(
	[id_status_acc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[status_payment]    Script Date: 24.02.2020 16:57:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[status_payment](
	[id_status_payment] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NOT NULL,
 CONSTRAINT [PK_status_payment] PRIMARY KEY CLUSTERED 
(
	[id_status_payment] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[status_request]    Script Date: 24.02.2020 16:57:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[status_request](
	[id_status_request] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NOT NULL,
 CONSTRAINT [PK_status_request] PRIMARY KEY CLUSTERED 
(
	[id_status_request] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[type_acc]    Script Date: 24.02.2020 16:57:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[type_acc](
	[id_type_acc] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NOT NULL,
 CONSTRAINT [PK_type_acc] PRIMARY KEY CLUSTERED 
(
	[id_type_acc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [index_client_email]    Script Date: 24.02.2020 16:57:11 ******/
CREATE UNIQUE NONCLUSTERED INDEX [index_client_email] ON [dbo].[client]
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_status_acc]    Script Date: 24.02.2020 16:57:11 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_status_acc] ON [dbo].[status_acc]
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_status_payment]    Script Date: 24.02.2020 16:57:11 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_status_payment] ON [dbo].[status_payment]
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [index_name]    Script Date: 24.02.2020 16:57:11 ******/
CREATE UNIQUE NONCLUSTERED INDEX [index_name] ON [dbo].[status_request]
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [index_type_acc_name]    Script Date: 24.02.2020 16:57:11 ******/
CREATE UNIQUE NONCLUSTERED INDEX [index_type_acc_name] ON [dbo].[type_acc]
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Acc]  WITH CHECK ADD  CONSTRAINT [FK_Acc_client] FOREIGN KEY([client_id])
REFERENCES [dbo].[client] ([id_client])
GO
ALTER TABLE [dbo].[Acc] CHECK CONSTRAINT [FK_Acc_client]
GO
ALTER TABLE [dbo].[Acc]  WITH CHECK ADD  CONSTRAINT [FK_Acc_credit_rate] FOREIGN KEY([credit_rate_id])
REFERENCES [dbo].[credit_rate] ([id_credit_rate])
GO
ALTER TABLE [dbo].[Acc] CHECK CONSTRAINT [FK_Acc_credit_rate]
GO
ALTER TABLE [dbo].[Acc]  WITH CHECK ADD  CONSTRAINT [FK_Acc_status_acc] FOREIGN KEY([status_acc_id])
REFERENCES [dbo].[status_acc] ([id_status_acc])
GO
ALTER TABLE [dbo].[Acc] CHECK CONSTRAINT [FK_Acc_status_acc]
GO
ALTER TABLE [dbo].[Acc]  WITH CHECK ADD  CONSTRAINT [FK_Acc_type_acc] FOREIGN KEY([type_acc_id])
REFERENCES [dbo].[type_acc] ([id_type_acc])
GO
ALTER TABLE [dbo].[Acc] CHECK CONSTRAINT [FK_Acc_type_acc]
GO
ALTER TABLE [dbo].[autopayment]  WITH CHECK ADD  CONSTRAINT [FK_autopayment_Acc] FOREIGN KEY([sender_id])
REFERENCES [dbo].[Acc] ([id_acc])
GO
ALTER TABLE [dbo].[autopayment] CHECK CONSTRAINT [FK_autopayment_Acc]
GO
ALTER TABLE [dbo].[autopayment]  WITH CHECK ADD  CONSTRAINT [FK_autopayment_Acc1] FOREIGN KEY([recipient_id])
REFERENCES [dbo].[Acc] ([id_acc])
GO
ALTER TABLE [dbo].[autopayment] CHECK CONSTRAINT [FK_autopayment_Acc1]
GO
ALTER TABLE [dbo].[autopayment]  WITH CHECK ADD  CONSTRAINT [FK_autopayment_autopayment_range] FOREIGN KEY([autopayment_range_id])
REFERENCES [dbo].[autopayment_range] ([id_autopayment_range])
GO
ALTER TABLE [dbo].[autopayment] CHECK CONSTRAINT [FK_autopayment_autopayment_range]
GO
ALTER TABLE [dbo].[payment]  WITH CHECK ADD  CONSTRAINT [FK_payment_Acc] FOREIGN KEY([sender_id])
REFERENCES [dbo].[Acc] ([id_acc])
GO
ALTER TABLE [dbo].[payment] CHECK CONSTRAINT [FK_payment_Acc]
GO
ALTER TABLE [dbo].[payment]  WITH CHECK ADD  CONSTRAINT [FK_payment_Acc1] FOREIGN KEY([recipient_id])
REFERENCES [dbo].[Acc] ([id_acc])
GO
ALTER TABLE [dbo].[payment] CHECK CONSTRAINT [FK_payment_Acc1]
GO
ALTER TABLE [dbo].[payment_history]  WITH CHECK ADD  CONSTRAINT [FK_payment_history_payment] FOREIGN KEY([payment_id])
REFERENCES [dbo].[payment] ([id_payment])
GO
ALTER TABLE [dbo].[payment_history] CHECK CONSTRAINT [FK_payment_history_payment]
GO
ALTER TABLE [dbo].[payment_history]  WITH CHECK ADD  CONSTRAINT [FK_payment_history_status_payment] FOREIGN KEY([status_payment_id])
REFERENCES [dbo].[status_payment] ([id_status_payment])
GO
ALTER TABLE [dbo].[payment_history] CHECK CONSTRAINT [FK_payment_history_status_payment]
GO
ALTER TABLE [dbo].[request]  WITH CHECK ADD  CONSTRAINT [FK_request_client] FOREIGN KEY([client_id])
REFERENCES [dbo].[client] ([id_client])
GO
ALTER TABLE [dbo].[request] CHECK CONSTRAINT [FK_request_client]
GO
ALTER TABLE [dbo].[request]  WITH CHECK ADD  CONSTRAINT [FK_request_status_request] FOREIGN KEY([status_request_id])
REFERENCES [dbo].[status_request] ([id_status_request])
GO
ALTER TABLE [dbo].[request] CHECK CONSTRAINT [FK_request_status_request]
GO
ALTER TABLE [dbo].[request]  WITH CHECK ADD  CONSTRAINT [FK_request_type_acc] FOREIGN KEY([type_acc_id])
REFERENCES [dbo].[type_acc] ([id_type_acc])
GO
ALTER TABLE [dbo].[request] CHECK CONSTRAINT [FK_request_type_acc]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Уникальный идентификатор таблицы acc(Счет)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Acc', @level2type=N'COLUMN',@level2name=N'id_acc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Баланс счета' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Acc', @level2type=N'COLUMN',@level2name=N'balance_acc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Внешний ключ таблицы client (Клиент)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Acc', @level2type=N'COLUMN',@level2name=N'client_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Внешний ключ таблицы credit_rate(Кредитный тариф)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Acc', @level2type=N'COLUMN',@level2name=N'credit_rate_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Дата открытия счета' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Acc', @level2type=N'COLUMN',@level2name=N'date_open_acc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Дата закрытия счета' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Acc', @level2type=N'COLUMN',@level2name=N'date_close_acc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Внешний ключ таблицы Статус счета' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Acc', @level2type=N'COLUMN',@level2name=N'status_acc_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Внешний ключ таблицы Тип счета' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Acc', @level2type=N'COLUMN',@level2name=N'type_acc_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Счет' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Acc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Уникальный идентификатор таблицы autopayment(Автоплатеж)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'autopayment', @level2type=N'COLUMN',@level2name=N'id_autopayment'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Внешний ключ таблицы Клиент, отправитель' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'autopayment', @level2type=N'COLUMN',@level2name=N'sender_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Внешний ключ таблицы Клиент, получатель' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'autopayment', @level2type=N'COLUMN',@level2name=N'recipient_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Сумма автоплатежа' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'autopayment', @level2type=N'COLUMN',@level2name=N'sum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Комментарий к автоплатежу' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'autopayment', @level2type=N'COLUMN',@level2name=N'comm'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Дата автоплатежа' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'autopayment', @level2type=N'COLUMN',@level2name=N'date_payment'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Внешний ключ таблицы Диапазон автоплатежа' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'autopayment', @level2type=N'COLUMN',@level2name=N'autopayment_range_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Заморозка' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'autopayment', @level2type=N'COLUMN',@level2name=N'freezing'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Автоплатеж' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'autopayment'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Уникальный идентификатор таблицы payment_range (Диапазон автоплатежа)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'autopayment_range', @level2type=N'COLUMN',@level2name=N'id_autopayment_range'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Наименование диапазона' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'autopayment_range', @level2type=N'COLUMN',@level2name=N'name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Число - шаг автоплатежа' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'autopayment_range', @level2type=N'COLUMN',@level2name=N'periodicity'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Диапазон автоплатежа' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'autopayment_range'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Уникальный идентификатор таблицы client(Клиент)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'client', @level2type=N'COLUMN',@level2name=N'id_client'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Клиент' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'client'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Уникальный идентификатор таблицы credit_rate (Кредитный тариф)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'credit_rate', @level2type=N'COLUMN',@level2name=N'id_credit_rate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Наименование кредитного тарифа' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'credit_rate', @level2type=N'COLUMN',@level2name=N'name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Условие кредите' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'credit_rate', @level2type=N'COLUMN',@level2name=N'condition'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Процент кредита' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'credit_rate', @level2type=N'COLUMN',@level2name=N'procent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Лимит кредите' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'credit_rate', @level2type=N'COLUMN',@level2name=N'credit_limit'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Кредитный тариф' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'credit_rate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Уникальный идентификатор таблицы payment(Платеж)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'payment', @level2type=N'COLUMN',@level2name=N'id_payment'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Внешний ключ Таблицы Клиент, отправитель' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'payment', @level2type=N'COLUMN',@level2name=N'sender_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Внешний ключ таблицы Клиент , получатель' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'payment', @level2type=N'COLUMN',@level2name=N'recipient_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Сумма платежа' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'payment', @level2type=N'COLUMN',@level2name=N'sum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Комментарий' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'payment', @level2type=N'COLUMN',@level2name=N'comm'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Платеж' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'payment'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Уникальный идентификатор таблицы payment_history (История платежа)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'payment_history', @level2type=N'COLUMN',@level2name=N'id_payment_history'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Внешний ключ таблицы Платеж' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'payment_history', @level2type=N'COLUMN',@level2name=N'payment_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Внешний ключ таблицы Статус платежа' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'payment_history', @level2type=N'COLUMN',@level2name=N'status_payment_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Дата вехи в истории платежа' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'payment_history', @level2type=N'COLUMN',@level2name=N'date_check'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Причина отмены платежа' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'payment_history', @level2type=N'COLUMN',@level2name=N'rejection'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'История платежа' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'payment_history'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Уникальный идентификатор таблицы request (Заявка)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'request', @level2type=N'COLUMN',@level2name=N'id_request'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Доход' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'request', @level2type=N'COLUMN',@level2name=N'income'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Место работы' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'request', @level2type=N'COLUMN',@level2name=N'place_job'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Внешний ключ таблицы client (Клиент)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'request', @level2type=N'COLUMN',@level2name=N'client_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Внешний ключ таблицы status_request (Статус заявки)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'request', @level2type=N'COLUMN',@level2name=N'status_request_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Внешний ключ таблицы type_acc (Тип счета)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'request', @level2type=N'COLUMN',@level2name=N'type_acc_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Заявка' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'request'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Уникальный идентификатор таблицы status_acc (Статус счета' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'status_acc', @level2type=N'COLUMN',@level2name=N'id_status_acc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Статус счета' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'status_acc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Уникальный идентификатор таблицы status_payment(Статус платежа)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'status_payment', @level2type=N'COLUMN',@level2name=N'id_status_payment'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Наименование статуса платежа' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'status_payment', @level2type=N'COLUMN',@level2name=N'name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Статус платежа' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'status_payment'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Уникальный идентификатор таблицы status_request (Статус заявки)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'status_request', @level2type=N'COLUMN',@level2name=N'id_status_request'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Наименование статуса заявки' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'status_request', @level2type=N'COLUMN',@level2name=N'name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Статус заявки' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'status_request'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Уникальный идентификатор таблицы type_acc(Тип счета)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'type_acc', @level2type=N'COLUMN',@level2name=N'id_type_acc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Тип счета' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'type_acc'
GO
USE [master]
GO
ALTER DATABASE [paymentsystem] SET  READ_WRITE 
GO
