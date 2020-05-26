cmake_minimum_required(VERSION 3.16)
project(C C)

set(CMAKE_C_STANDARD 11)
MATH(EXPR stack_size "100 * 1024 * 1024")
#set(CMAKE_CXX_FLAGS "-Wl,--stack_size,${stack_size}")
set(CMAKE_EXE_LINKER_FLAGS "${CMAKE_EXE_LINKER_FLAGS} /STACK:30000000")
add_executable(C main.c)