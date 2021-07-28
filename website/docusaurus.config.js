/** @type {import('@docusaurus/types').DocusaurusConfig} */
module.exports = {
  title: "Traveler's Bag Build",
  url: 'https://zTBBz.github.com',
  baseUrl: '/TBB/',
  onBrokenLinks: 'throw',
  onBrokenMarkdownLinks: 'warn',
  favicon: 'img/favicon.ico',
  organizationName: 'zTBBz',
  projectName: 'TBB',
  themeConfig: {
    hideableSidebar: true,
    prism: {
      theme: require('prism-react-renderer/themes/dracula'),
      additionalLanguages: ['clike', 'csharp', 'bash'],
    },
    navbar: {
      hideOnScroll: true,
      title: "Traveler's Bag Build",
      logo: {
        alt: 'A red cog with an yellow-on-black emblem',
        src: 'img/logo.png',
      },
      items: [
        {
          type: 'doc',
          docId: 'intro',
          position: 'left',
          label: 'Introduction',
        },
        {
          href: 'https://github.com/zTBBz/TBB',
          position: 'right',
          className: 'header-github-link',
          'aria-label': 'GitHub repository',
        },
      ],
    },
    footer: {
      style: 'dark',
      links: [
        {
          title: 'Docs',
          items: [
            {
              label: 'Introduction',
              to: '/docs/intro',
            },
          ],
        },
        {
          title: 'Community',
          items: [
            {
              label: 'Streets of Rogue Discord',
              href: 'https://discord.com/invite/streetsofrogue',
            },
            {
              label: 'RU Streets of Rogue Discord',
              href: 'https://discord.gg/neDvsmk',
            },
          ],
        },
        {
          title: 'More',
          items: [
            {
              label: 'GitHub',
              href: 'https://github.com/zTBBz/TBB',
            },
          ],
        },
      ],
      copyright: `Copyright © ${new Date().getFullYear()} Traveler's Bag Build. Built with Docusaurus.`,
    },
  },
  presets: [
    [
      '@docusaurus/preset-classic',
      {
        docs: {
          sidebarPath: require.resolve('./sidebars.js'),
          editUrl:
            'https://github.com/zTBBz/TBB/edit/master/website/',
        },
        blog: {
          showReadingTime: true,
          editUrl:
            'https://github.com/zTBBz/TBB/edit/master/website/blog/',
        },
        theme: {
          customCss: require.resolve('./src/css/custom.css'),
        },
      },
    ],
  ],
};
