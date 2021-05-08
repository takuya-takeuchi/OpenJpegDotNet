ARG IMAGE_NAME
FROM ${IMAGE_NAME}:latest
LABEL maintainer "Takuya Takeuchi <takuya.takeuchi.dev@gmail.com>"

# Install tools to install .NET SDK
RUN apt-get update && apt-get install -y --no-install-recommends \
    ca-certificates \
    wget \
    apt-transport-https \
    curl

# Install the .NET SDK
ENV DOTNET_SDK_VERSION 3.1
RUN mkdir -p /usr/share/dotnet
RUN curl -SL -o dotnet.tar.gz https://download.visualstudio.microsoft.com/download/pr/614983bc-78eb-4673-b1ff-fe876660ae21/03523848937d401293a7abdb56a6a0e2/dotnet-sdk-3.1.408-linux-arm.tar.gz
RUN tar -zxf dotnet.tar.gz -C /usr/share/dotnet && rm dotnet.tar.gz
RUN ln -s /usr/share/dotnet/dotnet /usr/bin/dotnet

# Install dependencies to use dotnet
RUN apt-get update && apt-get install -y --no-install-recommends \
    libc6 \
    libgcc1 \
    libgssapi-krb5-2 \
    libicu60 \
    liblttng-ust0 \
    libssl1.0.0 \
    libstdc++6 \
    zlib1g

# Install sudo apt-get install -y libgdiplus
RUN apt-get update && apt-get install -y --no-install-recommends \
    libgdiplus \
 && apt-get clean && rm -rf /var/lib/apt/lists/*

# Trigger first run experience by running arbitrary cmd to populate local package cache
RUN dotnet help