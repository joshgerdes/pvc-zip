![PVC Build Engine](http://i.imgur.com/vyROdJJ.png)

pvc-zip
===========

This is a plugin to utilize the DotNetZip library to zip and unzip archives with the [PVC Build Engine](https://github.com/pvcbuild).

###Parameter Options

The plugin has the ability to take in the following parameters:

####PvcZip()

* **password** (*default: none*) - password to use with the zip archive created.
* **name** (*default: "Archive"*) - name of the zip archive that is created.
	
####PvcUnzip()

* **password** (*optional*) - password to used when unzipping a password-protected archive.

###Usage Examples

Basic Zip (outputs: Archive.zip):

```
pvc.Source("js/*", "css/*", "test.js", "test.css")
	.Pipe(new PvcZip())
	.Save(@"deploy");
```

Basic zip with password protection:

```
pvc.Source("js/*", "css/*", "test.js", "test.css")
	.Pipe(new PvcZip(password: "pass@word1"))
	.Save(@"deploy");
```

Basic zip with name of archive (outputs: Backup.zip):

```
pvc.Source("js/*", "css/*", "test.js", "test.css")
	.Pipe(new PvcZip(name: "Backup"))
	.Save(@"deploy");
```

Basic unzip:

```
pvc.Source("Archive.zip")
	.Pipe(new PvcUnzip())
	.Save(@"deploy");
```

Basic unzip with password protection:

```
pvc.Source("Archive.zip")
	.Pipe(new PvcUnzip("pass@word1"))
	.Save(@"deploy");
```