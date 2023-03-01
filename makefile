TARGET=/var/www/dotnet/razor

help:
	@echo "make all | build | deploy | run | clean | install | uninstall | help"

all:	build deploy run

build:
	dotnet publish -c Release /property:GenerateFullPaths=false

deploy:
	rm -rf /var/www/dotnet/razor/*
	sudo systemctl stop razor.service
	cp -r bin/Release/net6.0/publish/* $(TARGET)
	sudo systemctl start razor.service

run:
	$(TARGET)/RazorApp --urls=http://0.0.0.0:5000 --pathBase=/razor

clean:
	rm -rf bin obj $(TARGET)/*

install:
	sudo cp service/razor.service /etc/systemd/system
	sudo systemctl daemon-reload
	sudo systemctl start razor.service
	sudo systemctl enable razor.service

uninstall:
	sudo systemctl disable razor.service
	sudo rm -f /etc/systemd/system/razor.service
