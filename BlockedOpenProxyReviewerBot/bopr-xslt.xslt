<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="xml" indent="yes"/>
    <xsl:template match="/">
      <html>
        <head>
          <title>foo</title>
        </head>
        <body>
          <h1>Blocked Open Proxy Review Bot (BOPRbot) Run results:</h1>
            <table>
              <tr>
                <th>ID</th>
                <th>IP</th>
                <th>Timestamp</th>
                <th>Expiry</th>
                <th>Blocker</th>
                <th>Hits</th>
              </tr>
              <xsl:for-each select="catalog/cd">
                <tr>
                  <td>
                    <xsl:value-of select="id"/>
                  </td>
                  <td>
                    <xsl:value-of select="ip"/>
                  </td>
                  <td>
                    <xsl:value-of select="timestamp"/>
                  </td>
                  <td>
                    <xsl:value-of select="expiry"/>
                  </td>
                  <td>
                    <xsl:value-of select="blocker"/>
                  </td>
                  <td>
                    <xsl:value-of select="hits"/>
                  </td>
                </tr>
              </xsl:for-each>
            </table>
          </body>
      </html>
    </xsl:template>
</xsl:stylesheet>
