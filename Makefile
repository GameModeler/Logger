include ./Makefile.config
include ../release-all/Makefile-portable

# Packaging

release: build
	$(call start,"Copying SDK files")

	@mkdir -p out/lib
	@mkdir -p out/src
	@mkdir -p out/src/agent
	@mkdir -p out/Resources
	                      
	@sed "s#OS#Capptain.$(OSVERSION)#g" $(COMMON_RELEASE_FOLDER)/README.txt > out/lib/README.txt

	@cp $(COMMON_FOLDER)/code/agent-$(PLATFORM)/CapptainPage.cs out/src/agent

	@rm -f $(COMMON_FOLDER)/code/reach-$(PLATFORM)/Resources/[tT]humbs.db
	@cp -r $(COMMON_FOLDER)/code/reach-$(PLATFORM)/Resources    out/

	@cp -r $(COMMON_RELEASE_FOLDER)/LICENSE-*                           out/
	
	@cp -r $(COMMON_FOLDER)/$(NUGET_FOLDER)/$(PACKAGENUGETFULLNAME) $(COMMON_FOLDER)/$(RELEASE_FOLDER)/out/lib/$(PACKAGENUGETFULLNAME)
	
	@sed "s# OS # $(OSVERSION) #g" $(COMMON_RELEASE_FOLDER)/NOTICE.txt > out/NOTICE.txt

	@sed "s#URL#$(DOCUMENTATION_URL)#g" $(COMMON_RELEASE_FOLDER)/documentation.html > out/documentation.html
	
	$(call end)

	$(call start,"Packaging into $(PACKAGE_NAME).$(PACKAGE_EXTENSION)")

	@rm -rf $(PACKAGE_NAME)
	@cp -r out/ $(PACKAGE_NAME)
	@tar czf $(PACKAGE_NAME).$(PACKAGE_EXTENSION) -h $(PACKAGE_NAME)

	$(call end)

	$(call start,"Clean the folder")
	@rm -rf out
	@rm -rf $(PACKAGE_NAME)
	$(call end)

	@cp -r $(COMMON_FOLDER)/$(RELEASE_FOLDER)/$(PACKAGE_NAME).$(PACKAGE_EXTENSION) $(COMMON_FOLDER)/$(NUGET_FOLDER)/$(PACKAGE_NAME).$(PACKAGE_EXTENSION)
	
	$(call status,"Packaging complete.")
	
nuget: build

	$(call start,"Copying SDK files")

	@mkdir -p out/lib
	@mkdir -p out/src
	@mkdir -p out/src/agent
	@mkdir -p out/Resources
	                      
	@sed "s#OS#Capptain.$(OSVERSION)#g" $(COMMON_RELEASE_FOLDER)/README.txt > out/lib/README.txt

	@cp $(COMMON_FOLDER)/code/agent-$(PLATFORM)/CapptainPage.cs out/src/agent

	@rm -f $(COMMON_FOLDER)/code/reach-$(PLATFORM)/Resources/[tT]humbs.db
	@cp -r $(COMMON_FOLDER)/code/reach-$(PLATFORM)/Resources    out/

	@cp -r $(COMMON_RELEASE_FOLDER)/LICENSE-*                           out/
	
	@sed "s# OS # $(OSVERSION) #g" $(COMMON_RELEASE_FOLDER)/NOTICE.txt > out/NOTICE.txt

	@sed "s#URL#$(DOCUMENTATION_URL)#g" $(COMMON_RELEASE_FOLDER)/documentation.html > out/documentation.html
	
	$(call end)

	$(call start,"Packaging into $(PACKAGE_NAME).$(PACKAGE_EXTENSION)")

	@rm -rf $(PACKAGE_NAME)
	@cp -r out/ $(PACKAGE_NAME)
	@tar czf $(PACKAGE_NAME).$(PACKAGE_EXTENSION) -h $(PACKAGE_NAME)

	$(call end)

	$(call start,"Clean the folder")
	@rm -rf out
	@rm -rf $(PACKAGE_NAME)
	$(call end)

	$(call status,"Packaging complete.")
	
	$(call start,"Create the NuGet folder")

	@mkdir -p $(NUGET_TEMP_FOLDER)/lib/win # target win
	@mkdir -p $(NUGET_TEMP_FOLDER)/content

	@tar xfz $(PACKAGE_COMPLETE) --directory $(NUGET_TEMP_FOLDER)
	
	@cp -r sdk/* $(NUGET_TEMP_FOLDER)/lib/win
	@cp -r $(NUGET_TEMP_FOLDER)/$(PACKAGE_NAME)/Resources $(NUGET_TEMP_FOLDER)/content/

	@rm -rf $(NUGET_TEMP_FOLDER)/$(PACKAGE_NAME)
	@rm -rf $(PACKAGE_COMPLETE)

	$(call end)

	$(call start,"Prepare the .nuspec file")

	@sed -e 's#@PACKAGENUGETNAME#$(PACKAGENUGETNAME)#g' \
		 -e 's#@OWNER#$(OWNER)#g' \
		 -e 's#@VERSION#$(VERSION)#g' \
	     -e 's#@DOCUMENTATION_URL#$(DOCUMENTATION_URL)#g' \
	     -e 's#@TOS_URL#$(TOS_URL)#g' \
	     -e 's#@ICON_URL#$(ICON_URL)#g' \
	     $(NUGET_SPEC) > $(NUGET_TEMP_FOLDER)/$(NUGET_SPEC)

	$(call end)

	$(call start,"Create the .nupkg file")

	@$(COMMON_RELEASE_FOLDER)/nuget Pack $(NUGET_TEMP_FOLDER)/$(NUGET_SPEC) -BasePath $(NUGET_TEMP_FOLDER) -OutputDirectory .
	@rm -rf $(NUGET_TEMP_FOLDER)
	
	@cp -r $(COMMON_FOLDER)/$(RELEASE_FOLDER)/$(PACKAGENUGETFULLNAME) $(COMMON_FOLDER)/$(NUGET_FOLDER)/$(PACKAGENUGETFULLNAME)

	$(call end)
	$(call status,"NuGet packaging complete.")
