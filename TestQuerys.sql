select * from dbo.users

go

update dbo.users set IsActive = 1

insert into dbo.users (name, Nickname, email, password, CreatedAt, CreatedBy) values 
('Miguel Jose Mata Ramos', 'miguelmodd', 'miguelmodd@gmail.com', 'jose@123A', GETDATE(), 'SYSTEM')
GO
insert into dbo.users (name, Nickname, email, password, CreatedAt, CreatedBy) values 
('Miguel Mata', 'mmata', 'mmata@altice.com.do', 'jose@123A', GETDATE(), 'SYSTEM')
