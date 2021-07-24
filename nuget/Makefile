.DEFAULT_GOAL := help

help: ## print this message
	@echo "Example operations by makefile."
	@echo ""
	@echo "Usage: make SUB_COMMAND argument_name=argument_value"
	@echo ""
	@echo "Command list:"
	@echo ""
	@printf "\033[36m%-40s\033[0m %-50s %s\n" "[Sub command]" "[Description]" "[Example]"
	@grep -E '^[/a-zA-Z0-9_-]+:.*?## .*$$' $(MAKEFILE_LIST) | perl -pe 's%^([/a-zA-Z0-9_-]+):.*?(##)%$$1 $$2%' | awk -F " *?## *?" '{printf "\033[36m%-40s\033[0m %-50s %s\n", $$1, $$2, $$3}'
	
run-test-ubuntu18-cpu-x64-desktop: ## run build container for ubuntu18 cpu x64 on desktop
	@pwsh RunTestContainer.ps1 cpu 64 desktop ubuntu 18 "/x64"

run-test-ubuntu18-arm-arm64-desktop: ## run build container for ubuntu18 mkl x64 on desktop
	@pwsh RunTestContainer.ps1 arm 64 desktop ubuntu 18 "/arm64"