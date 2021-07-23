FROM ubuntu:18.04
LABEL maintainer "Takuya Takeuchi <takuya.takeuchi.dev@gmail.com>"

# install package to build
RUN apt-get update && apt-get install -y \
    build-essential \
    tar \
    wget

# install latest cmake
ENV CMAKE_FILE cmake-3.19.4-Linux-x86_64.tar.gz
ENV CMAKE_URL https://github.com/Kitware/CMake/releases/download/v3.19.4/${CMAKE_FILE}
ENV CMAKE_URL_FILE ${CMAKE_FILE}
RUN wget ${CMAKE_URL} \
 && tar -xzf ${CMAKE_FILE} \
 && rm ${CMAKE_FILE} \
 && mv ${CMAKE_FILE%.tar.gz} /opt/cmake \
 && ln -s /opt/cmake/bin/* /usr/bin

# set compiler
ENV CMAKE_C_COMPILER=/usr/bin/gcc
ENV CMAKE_CXX_COMPILER=/usr/bin/g++

# Register Microsoft key and feed
RUN apt-get update && apt-get install -y \
    apt-transport-https
RUN wget -q https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb
RUN dpkg -i packages-microsoft-prod.deb && rm packages-microsoft-prod.deb
RUN apt-get update && apt-get install -y \
    powershell

# Support python build
RUN apt-get update && apt-get install -y \
    python3-distutils \
    python3-dev \
 && apt-get clean && rm -rf /var/lib/apt/lists/*