
CREATE ProCedure [dbo].[GetCustomerAppointments]
@CustomerID int,
@StartDate Date=NULL,
@EndDate Date=NULL

AS

If @StartDate is null
Begin
SET @EndDate =NULL

SELECT * FROM Appointments where CustomerId=@CustomerID
END
ELSE
Begin
IF @EndDate is null
SET @EndDate=DATEADD(DD,1,@StartDate)


SELECT * FROM Appointments Where CustomerId=@CustomerID AND AppointmentDate between @StartDate And @EndDate
END