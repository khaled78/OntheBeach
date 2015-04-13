SELECT 
      e.name Name
    , CAST(s.Annual_Amount AS VARCHAR(10)) + ' ' +  c.Unit 'Amount with out conversion'
    , CAST(s.annual_Amount * c.Conversion_Factor as VARCHAR(20)) + ' GBP' 'Amount in GBP'
FROM Employees e
JOIN Salaries s ON e.Id = s.Employee_id
JOIN Currencies c on c.Id = s.Currency