create trigger TR-Grupo on Grupo
For After Insert 
Begin 
 Declare @XMLAntes varchar(2000) = ''
 Declare @XMLDespues varchar(2000)
 Set @XMLDespues = (Select * From Inserted For XMLAuto) --Deleted-- --Update--
 Insert EventosdeMantenimiento (XMLAntes, XMLDespues, PostIn, PostBy, PostTime)
 values(@XMLAntes, @XMLDespues, GETDATE())

End

Create Trigger TR_Grupos_Update
on Grupo
For Update
Begin
	Insert EventosdeMantenimiento(Id, XMLAntes, XMLDespues, PostIn, PostBy, PostTime)
	Select A.XML, B.XML, '?', '?', GETDATE()
	From @Antes A, @Despues B
	Where dbo.FN_PK(A.XML) = dbo.FN.PK(B.XML)
End

Create dbo.FN_PK(xml varchar(2000)) returns Integer
Begin Id = ' , convierto a entero 

