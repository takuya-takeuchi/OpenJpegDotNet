ARG IMAGE_NAME
FROM ${IMAGE_NAME}:latest
LABEL maintainer "Takuya Takeuchi <takuya.takeuchi.dev@gmail.com>"

# Install tools to install .NET SDK
RUN apt-get update && apt-get install -y --no-install-recommends \
    ca-certificates \
    wget \
    apt-transport-https

# Register Microsoft key and feed
RUN wget -q https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb
RUN dpkg -i packages-microsoft-prod.deb && rm packages-microsoft-prod.deb

# Install the .NET SDK
ENV DOTNET_SDK_VERSION 3.1
RUN apt-get update && apt-get install -y --no-install-recommends \
    dotnet-sdk-${DOTNET_SDK_VERSION} \
 && apt-get clean && rm -rf /var/lib/apt/lists/*

# Install sudo apt-get install -y libgdiplus
RUN apt-get update && apt-get install -y --no-install-recommends \
    libgdiplus \
 && apt-get clean && rm -rf /var/lib/apt/lists/*

# Trigger first run experience by running arbitrary cmd to populate local package cache
RUN dotnet help