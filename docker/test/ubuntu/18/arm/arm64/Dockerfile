ARG IMAGE_NAME
FROM ${IMAGE_NAME}:latest
LABEL maintainer "Takuya Takeuchi <takuya.takeuchi.dev@gmail.com>"

# install gosu to execute process by non-root user
RUN apt-get update && apt-get install -y \
    gosu

# install package to build
RUN mkdir -p /usr/share/powershell
RUN curl -SL -o powershell.tar.gz https://github.com/PowerShell/PowerShell/releases/download/v6.2.7/powershell-6.2.7-linux-arm64.tar.gz
RUN tar -zxf powershell.tar.gz -C /usr/share/powershell && rm powershell.tar.gz
RUN chmod +x /usr/share/powershell/pwsh
RUN ln -s /usr/share/powershell/pwsh /usr/bin/pwsh

# copy build script and run
COPY runTest.sh /runTest.sh
RUN chmod 744 /runTest.sh
ENTRYPOINT ["./runTest.sh"]