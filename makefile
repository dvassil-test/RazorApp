TARGET=/var/www/dotnet/razor

help:
	@echo "make all | build | deploy | run | clean | install | uninstall | help"

all:	build deploy run

build:
	dotnet publish -c Release /property:GenerateFullPaths=false

deploy:
	rm -rf /var/www/dotnet/razor/*
	sudo systemctl stop razor.service <passwd
	cp -r bin/Release/net6.0/publish/* $(TARGET)
	sudo systemctl start razor.service <passwd

run:
	$(TARGET)/RazorApp --urls=http://0.0.0.0:5000 --pathBase=/razor

clean:
	rm -rf bin obj $(TARGET)/*

install:
	cp service/razor.service /etc/systemd/system
	sudo systemctl daemon-reload <passwd
	sudo systemctl start razor.service <passwd
	sudo systemctl enable razor.service <passwd

uninstall:
	sudo systemctl disable razor.service <passwd
	rm -f /etc/systemd/system/razor.service
