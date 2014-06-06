![PVC Build Engine](http://i.imgur.com/vyROdJJ.png)

pvc-zip
===========

This is a plugin to utilize the DotNetZip library to zip and unzip archives with the [PVC Build Engine](https://github.com/pvcbuild).

###Parameter Options

The plugin has the ability to take in the following parameters:

####PvcZip()

* **archiveName** (*default: "Archive"*) - name of the zip archive that is created.
	
###Usage Examples

Basic Zip (outputs: Archive.zip):

```
pvc.Source("js/*", "css/*", "test.js", "test.css")
	.Pipe(new PvcZip())
	.Save(@"deploy");
```

Basic zip with name of archive (outputs: Backup.zip):

```
pvc.Source("js/*", "css/*", "test.js", "test.css")
	.Pipe(new PvcZip("Backup"))
	.Save(@"deploy");
```

Basic unzip:

```
pvc.Source("Archive.zip")
	.Pipe(new PvcUnzip())
	.Save(@"deploy");
```