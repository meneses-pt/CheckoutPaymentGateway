if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PaymentsInfo]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
begin

	CREATE TABLE [dbo].[PaymentsInfo](
		  
		  [Id] [uniqueidentifier] NOT NULL,
		  [CardNumber] NVARCHAR(16) NULL,
		  [CardHolderName] NVARCHAR(50) NULL,
		  [ExpiryDate] NVARCHAR(5) NULL,
		  [Amount] FLOAT(53) NULL,
		  [Currency] NVARCHAR(3) NULL,
		  [CVV] NVARCHAR(3) NULL,
		  [Status] INT NULL
		
		, constraint [PK_PaymentsInfo] primary key ([Id])

	)

end
go