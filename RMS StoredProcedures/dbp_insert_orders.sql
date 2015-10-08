IF OBJECT_ID ( 'dbp_insert_orders', 'P' ) IS NOT NULL 
    DROP PROCEDURE dbp_insert_orders;
GO
 
CREATE PROCEDURE dbp_insert_orders 
	@pn_customer_id		NUMERIC(18),
	@pn_total_amount	NUMERIC(18,6),
	@pn_tax_amount		NUMERIC(18,6),
	@pn_net_amount		NUMERIC(18,6),
	@pn_comments		VARCHAR(500),
	@pn_output_id		INT OUTPUT
AS
SET NOCOUNT ON;
DECLARE @order_id INT;

INSERT INTO irfank.orders 
(	   customer_id,
	   total_amount,
	   tax_amount,
	   net_amount,
	   comments,
	   insert_datetime,
	   insert_user,
	   insert_process)
SELECT @pn_customer_id,
		@pn_total_amount,
		@pn_tax_amount,
		@pn_net_amount,
		@pn_comments,
	GetDate(),
	Host_Name(),
	'WebAPI'

SELECT @order_id = SCOPE_IDENTITY();
SELECT @pn_output_id = @order_id;

GO


/*** DEBUG  ***
BEGIN TRAN
DECLARE @pn_order_id INT
EXEC dbp_insert_orders @pn_customer_id =100,@pn_total_amount=12,@pn_tax_amount=14,@pn_net_amount=6,@pn_comments='xyz',@pn_output_id=@pn_order_id OUTPUT
SELECT @pn_order_id [outputid]
ROLLBACK


***********/