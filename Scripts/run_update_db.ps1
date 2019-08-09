param( $connectionString )

function GetFiles($path = $pwd, [string[]]$exclude) 
{ 
    foreach ($item in Get-ChildItem $path)
    {
        if ($exclude | Where {$item -like $_}) { continue }

        if (Test-Path $item.FullName -PathType Container) 
        {
            GetFiles $item.FullName $exclude
        } 
        else 
        { 
            invoke-sqlcmd -inputfile $item.FullName -ConnectionString $connectionString
        }
    } 
}

cd $PSScriptRoot
cd ..
cd CheckoutPaymentGateway.DataStorage/DbScripts
GetFiles(Get-Location)