// @ts-check

import { themes as prismThemes } from 'prism-react-renderer';

/** @type {import('@docusaurus/types').Config} */
const config = {
  title: 'IDAS Client Libraries',
  tagline: 'Documentation for Gandalan IDAS .NET and JavaScript Libraries',
  favicon: 'img/favicon.ico',

  url: 'https://gandalan.github.io',
  baseUrl: process.env.DOCS_BASE_URL || (process.env.NODE_ENV === 'production' ? '/idas-client-libs/' : '/'),

  organizationName: 'gandalan',
  projectName: 'idas-client-libs',

  onBrokenLinks: 'throw',
  onBrokenMarkdownLinks: 'warn',

  i18n: {
    defaultLocale: 'en',
    locales: ['en', 'de'],
  },

  presets: [
    [
      'classic',
      /** @type {import('@docusaurus/preset-classic').Options} */
      ({
        docs: {
          sidebarPath: './sidebars.js',
          editUrl: 'https://github.com/gandalan/idas-client-libs/tree/main/docs/',
          routeBasePath: '/',
        },
        blog: false,
        theme: {
          customCss: './src/css/custom.css',
        },
      }),
    ],
  ],

  themeConfig:
    /** @type {import('@docusaurus/preset-classic').ThemeConfig} */
    ({
      image: 'img/docusaurus-social-card.jpg',
      navbar: {
        title: 'IDAS Client Libraries',
        logo: {
          alt: 'Gandalan Logo',
          src: 'img/favicon_2gruen_32x32px.png',
        },
        items: [
          {
            type: 'docSidebar',
            sidebarId: 'guideSidebar',
            position: 'left',
            label: 'Guides',
          },
          {
            type: 'docSidebar',
            sidebarId: 'apiSidebar',
            position: 'left',
            label: 'API Reference',
          },
          {
            href: 'https://github.com/gandalan/idas-client-libs',
            label: 'GitHub',
            position: 'right',
          },
        ],
      },
      footer: {
        style: 'dark',
        links: [
          {
            title: 'Documentation',
            items: [
              {
                label: 'Guides',
                to: '/guides/intro',
              },
              {
                label: 'C# API',
                to: '/api/csharp',
              },
              {
                label: 'WebLibs API',
                to: '/api/weblibs',
              },
            ],
          },
          {
            title: 'Community',
            items: [
              {
                label: 'GitHub Discussions',
                href: 'https://github.com/gandalan/idas-client-libs/discussions',
              },
              {
                label: 'Issues',
                href: 'https://github.com/gandalan/idas-client-libs/issues',
              },
            ],
          },
          {
            title: 'More',
            items: [
              {
                label: 'GitHub',
                href: 'https://github.com/gandalan/idas-client-libs',
              },
            ],
          },
        ],
        copyright: `Copyright © ${new Date().getFullYear()} Gandalan GmbH.`,
      },
      prism: {
        theme: prismThemes.github,
        darkTheme: prismThemes.dracula,
        additionalLanguages: ['csharp', 'javascript', 'typescript', 'powershell', 'bash'],
      },
    }),
};

export default config;
