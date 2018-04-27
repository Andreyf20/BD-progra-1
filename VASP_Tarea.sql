Create Procedure VASP_RestaDiario
As
Begin
	Declare @fechaNow date = getDate();
	If exists (Select 1 From Eventos E where fk.TipoEvento = 48 and E.Fecha = @FechaNow)
		Return -50075
	Declare @Solicitudes Table (sec int identity(1,1), FK_Emp int,  fechaFinal date)
	Insert @Solicitudes(FK_Emp,  fechaFinal)
	Select S.FK_Emp, S.fechaFinal
	From dbo.SolicitudesVacacionesAprobadas S (nolock) 
	Where S.fechaFinal >= @fechaNow
	Order by S.ID
	Declare @EmpCumple Table (sec int identity(1,1), IdEmp int, email varchar(100), Saldo int, textoEmail varchar(2000))
	Insert @EmpCumple(idEmp, email, saldo, textoEmail)
	Select E.ID, E.Email, E.Saldo, ''
	From dbo.Empleados as E inner join @Solicitudes as S on S.FK_Emp = E.ID  
	Order by E.Id
	Update E
	Set textoEmail = 'Felicidades funcionario, su saldo de vacaciones es' + convert(varchar,E.Saldo - 1)
	From @EmpCumple E
	If exists (Select 1 Fom @EmpCumple E inner join dbo.Empleados EZ (nolock) 	on E.IdEmp = EZ.ID 	where E.Saldo-1 != Ez.Saldo)
		Return -50020
	Begin try
		If @@transcount = 0
		Begin
			Set insolution level Read Uncommitted
			Begin transaction
		End
		Insert email(email, IdEmp, texto)
		Select E.Email, E.IdEmp , E.textoEmail
		From @EmpCumple as E
		Order by E.IdEmp
		Set @MaxID = scope_Identity();
		Insert movimientos(FK_Empleado, FK_Email, Fecha , Monto, NuevoSaldo)
		Select E.IdEmp, @MaxID ,-1,E.Saldo
		From @EmpCumple
		Order by E.IdEmp
		Update E
		Set Saldo = Saldo -1
		From dbo.Empleado as E
		Inner join  @EmpCumple as EZ on E.ID = EZ.IdEmp 
		If @@transcount =1
			Commit
		Return 1
	End Try
	Begin Catch
		If @@transcount > 0 
			Rollback
		Return @@Error * -1 
	End Catch
End