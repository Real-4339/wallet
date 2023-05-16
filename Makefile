
# Variables


# Targets
clean:
	@echo "Cleaning up..."
	@find src -name "obj" -type d -exec rm -rf {} \;
	@find src -name "bin" -type d -exec rm -rf {} \;
	@echo "Cleaned! (removed obj/ and bin/ directories)"

build:
	@echo "Building..."
	@dotnet build src/
	@echo "Built!"

run:
	@echo "Running..."
	@dotnet run --project src/Wallet.Api/
	@echo "Ran!"

tests: 
	@echo "Running tests..."
	@dotnet test src/Wallet.Tests/
	@echo "Tests ran!"

net: clean run	