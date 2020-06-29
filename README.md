# praca-magisterska-webassembly-performance

This readme includes information about setting up tools for compiling to WASM. A web server will be required for every scenario, for example [Python web server](https://docs.python.org/3/library/http.server.html).
## C++/C to WASM

Compilation of C++/C files is pretty straightforward with official WASM compiler provided by [Emscripten](https://developer.mozilla.org/en-US/docs/WebAssembly/C_to_wasm).

Prerequisites:
 * get Emscripten SDK with: 
``` 
# Get the emsdk repo
git clone https://github.com/emscripten-core/emsdk.git

# Enter that directory
cd emsdk

# Fetch the latest version of the emsdk (not needed the first time you clone)
git pull

# Download and install the latest SDK tools.
./emsdk install latest

# Make the "latest" SDK "active" for the current user. (writes .emscripten file)
./emsdk activate latest

# Activate PATH and other environment variables in the current terminal
source ./emsdk_env.sh
```

Compiling:
```
emcc hello.c -s WASM=1 -o hello.html
```
Now start your web server.
## C# to WASM
C# source code can be compiled to WASM with Mono and Mono-Wasm SDKs.

Prerequisites:
* get the [Mono SDK](https://www.mono-project.com/download/stable/), add CSC and MONO to PATH
* get the [Mono-Wasm latest successful build](https://jenkins.mono-project.com/job/test-mono-mainline-wasm/)

Compiling:
1. Compile C# code to .Net Assemblies with:
```
csc /target:library -out:Example.dll /noconfig /nostdlib /r:$WASM_SDK/wasm-bcl/wasm/mscorlib.dll /r:$WASM_SDK/wasm-bcl/wasm/System.dll /r:$WASM_SDK/wasm-bcl/wasm/System.Core.dll /r:$WASM_SDK/wasm-bcl/wasm/Facades/netstandard.dll /r:$WASM_SDK/wasm-bcl/wasm/System.Net.Http.dll /r:$WASM_SDK/framework/WebAssembly.Bindings.dll /r:$WASM_SDK/framework/System.Net.Http.WebAssemblyHttpHandler.dll Example.cs
```
where **$WASM_SDK** is directory of mono-wasm SDK, **Example.cs** is name of compiled source code and **Example.dll** is name of output file.

2. Publish assembly for WASM with:
```
mono $WASM_SDK/packager.exe --copy=always --out=./publish --asset=./index.html Example.dll
```
Please note that you need HTML template to run your WASM code (in this case index.html, it is included in my repo).

3. Go to /publish directory and run your web server.

## Java to WASM
Compilation of Java source code is done by using [ByteCoder tool](https://mirkosertic.github.io/Bytecoder/chapter-1/page-1-a/) 
Prerequisites:
* get JDK
* get Bytecoder CLI Jar file from maven repository, f. ex. with:
```
wget https://repo.maven.apache.org/maven2/de/mirkosertic/bytecoder/bytecoder-cli/2020-05-15/bytecoder-cli-2020-05-15-executable.jar
```

Compiling:
1. Compile Java source code to JVM class file with:
```
javac SourceCode.java
```
2. Invoke the CLI and compile Java class file to WASM with:
```
java -jar bytecoder-cli-2020-05-15-executable.jar -classpath=. -mainclass=mypackage.SomeClass -builddirectory=. -backend=js -minify=false
```
Please note that **mypackage.SomeClass** has to include main() method.

3. Run your web server (index.html template to run Java compiled code is included in my repo)
