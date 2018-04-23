Create Procedure VASP_AcreditaDiario
	@FechaProceso date
As
Begin
	--Validar que el  proceso no corre dos o más veces para el mismo día
	If exists (Select 1 From Eventos E where fk.TipoEvento = 47 and E.Fecha = @FechaProceso)
		Return -50075
	--Validar que el proceso no brinque días
	Declare @maxFecha date
	Select e.MaxFecha = max(E.Fechas)
	From Eventos E
	Where E.FkTipoEvento =47
	If not (date add(@maxFecha,d,1=@FechProceso)
		Return -50078
	Declare @EmpCumple Table (sec int identity(1,1), IdEmp int, email varchar(100), Saldo int, textoEmail varchar(2000))
	--Uso variable tabla para cargar todo lo encesario y trabajar sobre ella para uasr la tabla base (Empleados) lo menos posible para no bloquearla
	Insert @EmpCumple(idEmp, email, saldo, textoEmail)
	Select E.Id, E.Email, E.Saldo, ''
	From dbo.Empleados E (nolock) --uplock xlock
	Where dbo.VAFN(@FechaProc, E.FechaContrat) = 1
	Order by E.Id
	Update E
	Set textoEmail = 'Felicidades funcionario, su saldo de vacaciones es' + convert(varchar,E.Saldo)
	From @EmpCumple E

	If exists (Select 1 Fom @EmpCumple E ,	inner join dbo.Empleados EZ (nolock) 	on El.IdEmp = EZ.ID 	where E.Saldo+1<>Ez.Saldo)
		Return -5002T
	Begin try
	--Control para evitar anidacion de transacciones
		If @@transcount =0
		Begin
			Set insolution level Read Uncommitted
			Begin transaction
		End
	
		Insert email(email, FK_Empleado, texto)
		Select E.Email, E.ID_Emp , E.textoEmail
		From @EmpCumple
		Order by E.IdEmp
		Set @MaxID = scope_Identity()
		Set @Q = Select count(1) From @EmpCumple --cant filas insertadas
	
		Insert movimientos(FK_Empleado, FK_Email, Fecha , Monto, NuevoSaldo)
		Select E.IdEmp, @MaxID -@Q + E.Sec,1,E.Saldo
		From @EmpCumple
		Order by E.IdCumple
	
		Update E
		Set Saldo = EZ.Saldo
		From dbo.Empleado E
		Inner join  @EmpCumple  on EI.Id = EZ.IdEmp
	
		If @@transcount =1
			Commit
		Return @Q --Cantidad De Filas procesadas
	End Try
	Begin Catch
		If @@transcount > 0 
			Rollback
		Return @@Error * -1 
	End Catch
End