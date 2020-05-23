cmake_minimum_required(VERSION 3.16)
project(C C)

set(CMAKE_C_STANDARD 11)
MATH(EXPR stack_size "20 * 1024 * 1024")
set(CMAKE_EXE_LINKER_FLAGS "-Wl,--stack,${stack_size}")
add_executable(C main.c)