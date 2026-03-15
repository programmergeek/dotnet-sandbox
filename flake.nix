{
  description = ".NET project sandbox";

  inputs = {
    nixpkgs.url = "github:nixos/nixpkgs?ref=nixos-unstable";
    flake-utils.url = "github:numtide/flake-utils";
  };

  outputs = { self, nixpkgs, flake-utils }@inputs: 
    flake-utils.lib.eachDefaultSystem(system: 
	let
	    pkgs = nixpkgs.legacyPackages.${system};
	in {
	    devShells.default = pkgs.mkShell {
		    buildInputs = with pkgs; [
			dotnetCorePackages.sdk_9_0_1xx
			dotnetCorePackages.sdk_9_0_1xx-bin
		    ];
		};
	}
    );
}
