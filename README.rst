=========================================
XAF Nullable<bool> Property Editor - v1.0
=========================================
-----------------------------
Compatible with XAF versions:
-----------------------------
- 12.1.10
- **WEB only** (for win solution you can check `Boolean property editor`_ solution, however I haven't tested it yet)
- **Checkbox display mode only** (there is also a combobox display mode)

.. _Boolean property editor: http://www.devexpress.com/Support/Center/Question/Details/Q265460

-----------
Description
-----------
This is a feature for **DevExpress eXpressAppFramework (XAF)** that provides Nullable<bool> Property Editor - automatic mechanism that enables three state checkboxes with Nullable bool properties.

**Functionality**

- Turns on "ASPxCheckBox.AllowGrayed" flag for all editors whose property type is Nullable<bool> (bool?)
- Works also for properties from aggregated objects

**Example of use**

Just include this property editor to your project.
Have fun!

------------
Installation
------------
#. Install XAF_.
#. Get the source code for this plugin from github_, either using git_, or downloading directly:

   - To download using git, install git and then type 
     ``git clone git@github.com:KrzysztofKielce/xaf-xaf-propertyeditor-nullable_bool.git backup``
     at the command prompt (on Linux, Windows is a bit different)
   - To download directly, go to the `project page`_ and click **Download**

#. Open a XAF Web project (or create one) and include the property editor file.


.. _XAF: http://go.devexpress.com/DevExpressDownload_UniversalTrial.aspx
.. _git: http://git-scm.com/
.. _github:
.. _project page: https://github.com/KrzysztofKielce/xaf-xaf-propertyeditor-nullable_bool


----------
Disclaimer
----------
This is **beta** code.  It is probably okay for production environments, but may not work exactly as expected.  Refunds will not be given.  If it breaks, you get to keep both parts.

-------
Release
-------
All code herein is Copylefted_.

.. _Copylefted: http://en.wikipedia.org/wiki/Copyleft

---------
About XAF
---------
The eXpressApp Framework (XAF) is a modern and flexible application framework that allows you to create powerful line-of-business applications that simultaneously target Windows and the Web. XAF's scaffolding of the database and UI allows you to concentrate on business rules without the many distractions and tedious tasks normally associated with Windows and Web development. XAF's modular design facilitates a plug and play approach to common business requirements such as security and reporting.

XAF's advantages when compared with a more traditional approach to app development are profound. See for yourself and learn why XAF can radically increase productivity and help you bring solutions to market faster than you've ever thought possible.

For more information, visit:

http://www.devexpress.com/Products/NET/Application_Framework/
