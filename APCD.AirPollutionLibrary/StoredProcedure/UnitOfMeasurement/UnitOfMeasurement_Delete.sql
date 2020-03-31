USE AirPollution

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[UnitOfMeasurement_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[UnitOfMeasurement_Delete]

GO

USE AirPollution

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: AirPollution
Procedure Name: UnitOfMeasurement_Delete
Author: Mike Farris
Date: 10/04/2011
Description:  Deletes the record with the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.UnitOfMeasurement_Delete(
    @UnitOfMeasurementID    int
)

AS

BEGIN

    DELETE FROM UnitOfMeasurement
    WHERE
        UnitOfMeasurementID = @UnitOfMeasurementID

END

RETURN

GO

