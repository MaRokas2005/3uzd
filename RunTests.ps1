Write-Host "Building and running C# program..."

# --- Method 1: Using an array of strings and pipe ---
# Input values are provided one per line, matching Console.ReadLine() calls
"", "4", "30", "100", "5", "3" ,"3", "2", "1", "1", "1", "30", "100", "3", "3" ,"2", "1", "1", "1", "1", "60", "100", "5", "11" ,"3", "2", "5", "5", "1", "60", "20", "5", "11" ,"3", "2", "5", "5", "1", "1000", "100", "10", "10", "7", "3", "4", "4", "2" | dotnet run

Write-Host "------------------------------------"