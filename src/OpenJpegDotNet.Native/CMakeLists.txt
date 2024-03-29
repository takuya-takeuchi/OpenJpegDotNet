cmake_minimum_required(VERSION 3.0.0)
cmake_policy(SET CMP0053 NEW)
cmake_policy(SET CMP0054 NEW)

set(PROJ_NAME OpenJpegDotNetNative)
set(CMAKE_CXX_STANDARD 17)
set(CMAKE_CXX_STANDARD_REQUIRED ON)

# It means that CMakeLists.txt version rather than library version
project(${PROJ_NAME} VERSION 1.0.0)

# OS info
message("-------------------------------------------------------")
message("-- CMAKE_SYSTEM_INFO_FILE: ${CMAKE_SYSTEM_INFO_FILE}")
message("-- CMAKE_SYSTEM_NAME:      ${CMAKE_SYSTEM_NAME}")
message("-- CMAKE_SYSTEM_PROCESSOR: ${CMAKE_SYSTEM_PROCESSOR}")
message("-- CMAKE_SYSTEM:           ${CMAKE_SYSTEM}")
message("-- CMAKE_C_COMPILER:       ${CMAKE_C_COMPILER}")
message("-- CMAKE_CXX_COMPILER:     ${CMAKE_CXX_COMPILER}")
string (REGEX MATCH "\\.el[1-9]" os_version_suffix ${CMAKE_SYSTEM})
message("-- os_version_suffix:      ${os_version_suffix}")
message("-- Project: ${CMAKE_CURRENT_SOURCE_DIR}")
message("-- Binaries: ${CMAKE_CURRENT_BINARY_DIR}")
message("-------------------------------------------------------")

# Version info
set(VERSION_MAJOR 2)
set(VERSION_MINOR 4)
set(VERSION_PATCH 0)
set(VERSION_DATE 20210725)

# Only GCC requires -fPIC
if ("${CMAKE_CXX_COMPILER_ID}" STREQUAL "GNU")
	set(CMAKE_C_FLAGS "${CMAKE_C_FLAGS} -fPIC")
	set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -fPIC")
endif()

# set architecture
if (NOT ${CMAKE_GENERATOR} MATCHES "Visual Studio")
	if ("${TARGET_ARCH}" STREQUAL "x86")
        set(CMAKE_C_FLAGS "${CMAKE_C_FLAGS} -m32")
        set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -m32")
    elseif ("${TARGET_ARCH}" STREQUAL "x64")
        set(CMAKE_C_FLAGS "${CMAKE_C_FLAGS} -m64")
        set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -m64")
    endif()
endif()

# Select the release build type by default
if (NOT CMAKE_BUILD_TYPE)
    set(CMAKE_BUILD_TYPE "Release" CACHE STRING "" FORCE)
    message("-- CMAKE_BUILD_TYPE: ${CMAKE_BUILD_TYPE}")
endif()

# Set /bigobj for MSVC
if (${CMAKE_GENERATOR} MATCHES "Visual Studio")
	# C4819: The file contains a character that cannot be represented in the current code page
	# C4503: identifier' : decorated name length exceeded, name was truncated
	set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} /wd4819 /wd4503 /bigobj")

	# C4146: unary minus operator applied to unsigned type, result still unsigned
	if ("${CMAKE_SYSTEM_NAME}" STREQUAL "WindowsStore")
		set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} /wd4146 /wd4996 /ZW /EHsc")
	endif()
endif()

# set parallel build
if (${CMAKE_GENERATOR} MATCHES "Visual Studio")
    set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} /MP")
endif()

# openjpeg project submodule
find_package(OpenJPEG REQUIRED)

# create config file
configure_file(
    ${PROJECT_SOURCE_DIR}/openjpeg/config.hpp.in
    ${PROJECT_SOURCE_DIR}/openjpeg/config.hpp
    @ONLY)

configure_file(
    ${CMAKE_CURRENT_SOURCE_DIR}/version.rc.in
    ${CMAKE_CURRENT_BINARY_DIR}/version.rc
    @ONLY)

FILE(GLOB_RECURSE HEADERS ${PROJECT_SOURCE_DIR}/openjpeg/*.h)
FILE(GLOB_RECURSE SOURCES ${PROJECT_SOURCE_DIR}/openjpeg/*.cpp)

OPTION(ENABLE_NEON "Enable ARM NEON" OFF)
if (${ENABLE_NEON})
        # ARM64 ignore mfpu option
        # https://developer.arm.com/docs/dui0774/i/compiler-command-line-options/-mfpu
	#set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -O3 -mfpu=neon -fprofile-use -D ENABLE_NEON")
	set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -O3 -fprofile-use -D ENABLE_NEON")
endif()

if ("${CMAKE_SYSTEM_NAME}" STREQUAL "iOS")
    add_library(${PROJ_NAME} ${HEADERS}
                             ${SOURCES}
                             ${CMAKE_CURRENT_BINARY_DIR}/version.rc)
else()
    add_library(${PROJ_NAME} SHARED ${HEADERS}
                                    ${SOURCES}
                                    ${CMAKE_CURRENT_BINARY_DIR}/version.rc)
endif()

include_directories("${OPENJPEG_INCLUDE_DIRS}")

if (MSVC OR MSYS OR MINGW)
    list(APPEND STATIC_LIBRARIES
        openjp2
    )
elseif("${CMAKE_SYSTEM_NAME}" STREQUAL "iOS")
    list(APPEND STATIC_LIBRARIES
        openjp2
    )
elseif(APPLE)
    list(APPEND STATIC_LIBRARIES
        openjp2
    )
elseif("${CMAKE_SYSTEM_NAME}" STREQUAL "Android")
    list(APPEND STATIC_LIBRARIES
        openjp2
    )
elseif(UNIX AND NOT APPLE)
    list(APPEND STATIC_LIBRARIES
        openjp2
    )
else()
    message(FATAL_ERROR "Failed to link library")
endif()

target_link_libraries(${PROJ_NAME} ${STATIC_LIBRARIES})

set(CompilerFlags
    CMAKE_CXX_FLAGS
    CMAKE_CXX_FLAGS_DEBUG
    CMAKE_CXX_FLAGS_RELEASE
    CMAKE_C_FLAGS
    CMAKE_C_FLAGS_DEBUG
    CMAKE_C_FLAGS_RELEASE
)

set(CPACK_PROJECT_NAME ${PROJECT_NAME})
set(CPACK_PROJECT_VERSION ${PROJECT_VERSION})
include(CPack)