{
  description = ".NET project sandbox";

  inputs = {
    nixpkgs.url = "github:nixos/nixpkgs?ref=nixos-unstable";
    flake-utils.url = "github:numtide/flake-utils";
  };

  outputs = { self, nixpkgs, flake-utils }: 
    flake-utils.lib.eachDefaultSystem(system: 
	let
	    pkgs = nixpkgs.legacyPackages.${system};
	in {
	    devShells.default = pkgs.mkShell {
		    buildInputs = with pkgs; [
			dotnet-sdk_10
			roslyn-ls
			csharp-ls
		    ];
	    shellHook = ''
		export DOTNET_ROOT="${pkgs.dotnet-sdk_10}/share/dotnet"
		export PATH=$PATH:$HOME/.dotnet/tools

		# Install easy-dotnet CLI tool if not already present
		if ! command -v dotnet-easydotnet &> /dev/null; then
		    dotnet tool install --global easy-dotnet
		fi
		'';
		};
	}
    );
}
