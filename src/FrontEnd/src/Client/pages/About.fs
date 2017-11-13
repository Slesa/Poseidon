module Client.About

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Style
open Pages

let view () =
  [
      words 20 "Poseidon" 
      words 20 ("version " + ReleaseNotes.Version)
      //viewLink Page.Login "Please login into the Poseidon app"
      br []
      br []
      br []
      br []
      br []
      br []
      br []
      words 20 "Made with"
      a [ Href "https://safe-stack.github.io/" ] [ img [ Src "/images/safe_logo.png" ] ]
      words 15 "An end-to-end, functional-first stack for cloud-ready web development that emphasises type-safe programming."
      //br []
      //br []
      //br []
      //br []
      //words 20 ("version " + ReleaseNotes.Version) 
  ]