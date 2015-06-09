﻿$scriptpath = Split-Path $MyInvocation.MyCommand.Path
$url = "http://licenses.opendefinition.org/licenses/groups/all.json"


#if (!(Test-Path $scriptpath\License.json))
#{
    Invoke-WebRequest $url -OutFile $scriptpath\License.json
#}

$content = (Get-Content $scriptpath\License.json)
$content = $content.Replace("    ", "`t`t")

#$content = $content.Replace(""": {", """,") 
$content = $content.Replace(""": {", """,")
$content = $content.Replace("  """, "`t{`n`t`t""License"": {`n`t`t""name"": """)
#$content = $content.Replace("  ", "`t")
#$content = $content.Replace("},", "} },") 


#$content = "[" + $content + "]"
$content | Set-Content $scriptpath\License.json
