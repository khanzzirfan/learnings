IF OBJECT_ID ( 'dbp_insert_customer_data', 'P' ) IS NOT NULL 
    DROP PROCEDURE dbp_insert_customer_data;
GO
 
CREATE PROCEDURE dbp_insert_customer_data 
	@pn_Name		VARCHAR(50),
	@pn_phone		VARCHAR(50)
AS
SET NOCOUNT ON;

INSERT INTO customer 
(	   customer_name,
	   customer_phone,
	   insert_datetime,
	   insert_user,
	   insert_process)
SELECT @pn_name,
	@pn_phone,
	GetDate(),
	Host_Name(),
	'WebAPI'
SELECT @customer_id = SCOPE_IDENTITY();
SELECT @customer_id [customer_id];

GO
