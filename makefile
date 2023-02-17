TARGET=/var/www/dotnet/razor

all:	build deploy run

build:
	dotnet publish -c Release /property:GenerateFullPaths=false

deploy:
	rm -rf /var/www/dotnet/razor/*
	cp -r bin/Release/net6.0/publish/* $(TARGET)

run:
	$(TARGET)/RazorApp --urls=http://0.0.0.0:5000 --pathBase=/razor

clean:
	rm -rf bin obj $(TARGET)/*

install:
	cp service/razor.service /etc/systemd/system
	systemctl daemon-reload
	systemctl start razor.service
	systemctl enable razor.service

uninstall:
	systemctl disable razor.service
	rm -f /etc/systemd/system/razor.service
