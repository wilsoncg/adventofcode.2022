module Day6

open System

type ReadOnlySpan<'T> with
    member sp.GetSlice(startIdx, endIdx) =
        let s = defaultArg startIdx 0
        let e = defaultArg endIdx sp.Length
        sp.Slice(s, e - s)

let StartOfPacketMarker (i:string) (seperator:string) =
    let examine (s:string) = 
        let charByFrequency = Seq.zip (seq { 'a'..'z' }) [ 0 ]
        let mapCharsByFrequency = Map charByFrequency
        for i in 0 .. s.Length do
            let c = s[i]
            mapCharsByFrequency[c] = mapCharsByFrequency[c] + 1
        let numWindows = (s.Length-4) + 1
        let span = s.AsSpan()
        let frequencies = [ 
          for a = 1 to numWindows do
            let endIndex = if(a+4) > i.Length then i.Length else a+4 
            let slice = span.Slice(a, endIndex)
            let frequencyForSlice = [
              for b in 0 .. slice.Length do 
                let r = if mapCharsByFrequency[slice[b]] = 0 then true else false
                yield r
              ]
            let reduced = frequencyForSlice |> Seq.reduce (&) 
            yield (a+4, reduced)
          ]
        let find = frequencies |> Seq.tryFind (fun f -> snd f = true)
        match find with
        | Some (index, frequency) -> index
        | None -> 0 

    let signals = 
      i.Split seperator 
      |> Array.where (fun f -> not(String.IsNullOrEmpty f))
      |> Seq.map examine
    0